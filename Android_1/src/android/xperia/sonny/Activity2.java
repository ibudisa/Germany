package android.xperia.sonny;

import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.*;
import android.os.Bundle; 
import android.os.Message;
import android.os.SystemClock;
import android.view.Menu;
import  android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.LayoutInflater;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.ProgressBar;
import android.widget.RadioGroup;
import android.widget.TabHost;
import android.widget.TextView;
import android.widget.Toast;
import android.os.Handler;
import java.util.ArrayList;
import java.util.List;
import java.lang.*;
import java.io.*; 

public class Activity2 extends Activity { 
	
	private EditText text1;
	private EditText text2;
	private TextView tview;
	private RadioGroup types;
	private String idval;
	private String status;
	
	Employee einsert;
	
	public void onCreate(Bundle savedInstanceState)
	{
			
		super.onCreate(savedInstanceState);
		setContentView(R.layout.second);
		
		Bundle extras = getIntent().getExtras();
		if (extras == null) {
			return;
		}
		
		try
		{
		String value1 = extras.getString("Value1");
		if (value1 != null ) {
			
			MessageBox(value1);
			
			String[] polje = value1.split(" ");
			
			text1 = (EditText)findViewById(R.id.edit1);
		    text2 = (EditText)findViewById(R.id.edit2);
		    tview = (TextView)findViewById(R.id.textView1);
		    types = (RadioGroup)findViewById(R.id.rbtngroup);
		    
		    
		    tview.setText(polje[0]);
			text1.setText(polje[1]);			
			text2.setText(polje[2]); 			
			 
		}}
		catch(Exception e)
		{
			MessageBox(e.getMessage());		
		}
	
		
		Button btnInsert= (Button)findViewById(R.id.buttonInsert);
		 
		btnInsert.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				
				final DB db = new DB(Activity2.this);
				try
				{
					switch (types.getCheckedRadioButtonId()) {
					case R.id.rbtninsert:
					  db.open();
					  einsert = db.add(text1.getText().toString(), text2.getText().toString());
					  db.close();
					  setValues(new Integer(einsert.getId()).toString(),"inserted");
					break;
					case R.id.rbtndelete:
						db.open();
						db.delete(Integer.parseInt(tview.getText().toString()));
						db.close();
						setValues(tview.getText().toString(),"deleted");
					break;
					case R.id.rbtnedit:
						db.open();
					    db.update(Integer.parseInt(tview.getText().toString()),text1.getText().toString(), text2.getText().toString());
					    db.close(); 
					    setValues(tview.getText().toString(),"updated");					   
					break;
				  } 
				}
				catch(Exception e)
				{
					 MessageBox(e.getMessage());
				}
				finish();
			}
		});
	}

	public void onClick(View view) { 

        //setValues(null,null);
		finish();
	}
	
	public void MessageBox(String message){
	    Toast.makeText(this,message,Toast.LENGTH_SHORT).show();
	}
	
	private void setValues(String id,String st)
	{
	  this.idval=id;
	  this.status=st;
	}
	
	 
	@Override
	public void finish() {
		Intent data = new Intent();
		data.putExtra("returnKey1", this.idval);
	 	data.putExtra("returnKey2", this.status);
		setResult(RESULT_OK, data);
		super.finish();
	}
}

 