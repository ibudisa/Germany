package android.xperia.sonny;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class MySQLiteHelper extends SQLiteOpenHelper {

	static final String dbName="EmployeesDB";
	static final String employeeTable="Employees";
	static final String colID="EmployeeID";
	static final String colName="EmployeeName";
	static final String colAge="Age";
	
	 
	public MySQLiteHelper(Context ctx)
	{
		 super(ctx, dbName, null,33);
	} 
	@Override
	public void onCreate(SQLiteDatabase db) {
		  db.execSQL("CREATE TABLE "+employeeTable+"  ("+colID+" INTEGER PRIMARY KEY AUTOINCREMENT, " +
		  		""+ colName+" TEXT, "+colAge+" INTEGER)");

	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldversion, int newversion) {
		 db.execSQL("DROP TABLE IF EXISTS "+employeeTable);

	}

	 
}
