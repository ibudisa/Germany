package android.xperia.sonny;

import java.util.ArrayList;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;

public class DB {
	
	private SQLiteDatabase database;
	private MySQLiteHelper dbHelper;
	private String[] allColumns = { MySQLiteHelper.colID,
			MySQLiteHelper.colAge,MySQLiteHelper.colName };

	public DB(Context context) {
		dbHelper = new MySQLiteHelper(context);
	}

	public void open() throws SQLException {
		database = dbHelper.getWritableDatabase();
	}

	public void close() {
		dbHelper.close();
	}

	public Employee add(String name,String age) {
		ContentValues values = new ContentValues();
		values.put(MySQLiteHelper.colName, name);
		values.put(MySQLiteHelper.colAge, age);

		long insertId = database.insert(MySQLiteHelper.employeeTable, null,
				values);
		// To show how to query
		Cursor cursor = database.query(MySQLiteHelper.employeeTable,
				allColumns, MySQLiteHelper.colID + " =?", new String[] {(new Long(insertId)).toString()}, null,
				null, null, null);
		cursor.moveToFirst();
		return cursorToEmployee(cursor);
	}
	
	public int update(int id,String name,String age) {
		ContentValues values = new ContentValues();
		values.put(MySQLiteHelper.colName, name);
		values.put(MySQLiteHelper.colAge, age);

		int Id = database.update(MySQLiteHelper.employeeTable, values,MySQLiteHelper.colID+"=?", 
			    new String []{String.valueOf(id)});   
		 
		return Id;
	}

	public void delete(int id) {
		//int id = emp.getId();
		System.out.println("Comment deleted with id: " + id);
		database.delete(MySQLiteHelper.employeeTable, MySQLiteHelper.colID + " = ?",new String[] {(new Integer(id)).toString()});
	}
	
	public Employee getEmployee(int empid) {
		 
		Cursor cursor = database.query(MySQLiteHelper.employeeTable,
				allColumns, MySQLiteHelper.colID +"=?", new String[] {(new Integer(empid)).toString()}, null, null, null);
		cursor.moveToFirst();
			Employee ee = cursorToEmployee(cursor);
	
		// Make sure to close the cursor
		cursor.close();
	  
		return  ee;
	}

	public List<Employee> getAllEmployees() {
		List<Employee> emps = new ArrayList<Employee>();
		Cursor cursor = database.query(MySQLiteHelper.employeeTable,
				allColumns, null, null, null, null, null);
		cursor.moveToFirst();
		while (!cursor.isAfterLast()) {
			Employee comment = cursorToEmployee(cursor);
			emps.add(comment);
			cursor.moveToNext();
		}
		// Make sure to close the cursor
		cursor.close();
		return emps;
	}

	private  Employee cursorToEmployee(Cursor cursor) {
		Employee e = new Employee();
		e.setId(cursor.getInt(0));
		e.setName(cursor.getString(1));
		e.setAge(cursor.getInt(2));
		return e;
	}

}
