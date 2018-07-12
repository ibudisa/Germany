package android.xperia.sonny;

import android.app.Activity;
import android.content.Context;
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
import android.widget.ProgressBar;
import android.widget.RadioGroup;
import android.widget.TabHost;
import android.widget.TextView;
import android.widget.Toast;
import android.os.Handler;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.lang.*;
import java.io.*;


public class Android_1Activity extends Activity {
	
	private ArrayAdapter<String> adapt;
	private List<String> imena = new ArrayList<String>();
	private Handler handler;
	private ProgressBar bar;
	private ListView list;
	private int progress=0;
	private  Thread thread; 
	private SQLiteQueryBuilder db;
	private static final int REQUEST_CODE = 10;
	private static final int REQUEST_CODE_1 = 100;
	private int i; 
	
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //requestWindowFeature(Window.FEATURE_PROGRESS);
        setContentView(R.layout.main);
        
        Thread thread = new Thread(myThread);
        
        try
        {      	   
        	bindList();	
        
        }
        catch(Exception e)
        {
           MessageBox(e.getMessage());
        }
        
         
        bar = (ProgressBar) findViewById(R.id.progressBar1);
        
   	    handler = new Handler(){

   	    	@Override
   	    	public void handleMessage(Message msg) {
   	    	// TODO Auto-generated method stub 
   	    	progress++;
   	    	bar.setProgress(progress); 
   	    }};
        
        Button btn = (Button)findViewById(R.id.button1);
        Button btn0 = (Button)findViewById(R.id.button2);
        
         
        
        list.setOnItemClickListener(new	AdapterView.OnItemClickListener()
        {
        	public void onItemClick(AdapterView<?> parent,View view, int position,long id) 
        	{
        		try
        		{
	        		String s = parent.getAdapter().getItem(position).toString();       		 
	        		 
	        		MessageBox(s);
	        		startSub2ndActivity(s);
        		}
        		catch(Exception e)
        		{
        			MessageBox(e.getMessage());
        		}
        		 
        	}});
        	
        btn.setOnClickListener(new View.OnClickListener() {
			
			
        	@Override
			public void onClick(View v) {
			try
			{ 			  				    
 		        
//		       
				 TextView txt = (TextView)findViewById(R.id.txtView1);
	        	 txt.setText("Unutar handlera!");	
	        	 
	        	 DB db = new DB(Android_1Activity.this);
		         db.open();
		    	 List<Employee> ees = db.getAllEmployees();
		         
			     
		         MessageBox(db.getEmployee(10).ToString());
	        	 
		         db.close();
		         
	        	 (new Thread(run)).start(); 
			}
			catch(Exception e)
			{
				MessageBox(e.getMessage());
			}
			}
		});         
        
        btn0.setOnClickListener(new View.OnClickListener() {
			
			@Override 
			public void onClick(View v){
			
				try
				{
					startSub3rdActivity(readStatistics());
				}
				catch(Exception e)
				{
					MessageBox(e.getMessage());
				}
			}    
		}); 
        
    }
    
    public List<String> stringList(List<Employee> list)
    {
    	List<String> str = new ArrayList<String>();
    	
    	for(Employee e:list)
    	{
    		str.add(e.ToString());
    	}
    	
    	return str;
    }

	public void MessageBox(String message){
	    Toast.makeText(this,message,Toast.LENGTH_SHORT).show();
	}  
	
	
	private void bindList()
	{
		DB db = new DB(this);
        db.open();
        
   	    List<Employee> ees = db.getAllEmployees();
   	    
        db.close();
        
        list=(ListView)findViewById(R.id.listView1);
        
        
        imena = stringList(ees);
        
        adapt = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,imena);
        
        list.setAdapter(adapt); 
        
        list.canScrollVertically(1);
	}
    
    private void setAdapter() {    	
    	 
    		//adapt.add("First");
        	//adapt.add("Second");    	
	
	}     
    
    
    private void startSub2ndActivity(String val)
    {
    	Intent i = new Intent(this, Activity2.class);
		i.putExtra("Value1", val);
		// Set the request code to any code you like, you can identify the
		// callback via this code
		startActivityForResult(i, REQUEST_CODE);
    }
    
    private void startSub3rdActivity(List<String> s)
    {      
      Intent in = new Intent(this,Activity_Statistics.class);
      
      for(String str:s)
      {
    	  String[] p = str.split(" ");
    	  
    	  in.putExtra(p[0], p[1]);    	  
    	   
      }
       startActivityForResult(in,REQUEST_CODE_1);
      
    }
    
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (resultCode == RESULT_OK && requestCode  == REQUEST_CODE) {
			
				if ((data.hasExtra("returnKey1"))&& (data.hasExtra("returnKey2"))) {
//					if((data.getExtras().getString("returnKey1")!=null)&&(data.getExtras().getString("returnKey2")!=null))
					
					bindList();
					
					String information = data.getExtras().getString("returnKey1")+" "+data.getExtras().getString("returnKey2");
					
					writeStatistics(information);
					
					MessageBox(information);
				}
			 }
		      
		else if (resultCode == RESULT_OK && requestCode  == REQUEST_CODE_1)
		{
			bindList();
		}

	}

    private Runnable myThread = new Runnable(){

    	@Override
    	public void run() {
    	// TODO Auto-generated method stub
    	while (progress<100){
    	try{
    		handler.sendMessage(Message.obtain());
    		 Thread.sleep(1000);
    	} 
    	catch(Throwable t){
    	}
       }
      }
    };    
    
    private void writeStatistics(String info) {
    	String eol = System.getProperty("line.separator");
    	try {
    		
    		FileOutputStream fos = openFileOutput("Statistika",Context.MODE_APPEND);
    		BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(fos));
    		
    		writer.write(info+eol); 
    		 
    		writer.close();
    		 
    	} catch (Exception e) {
    		e.printStackTrace();
    	}   	 
    }
    
     private int count()
     {
    	 int count=0;
    	 try
    	 {
    	 BufferedReader input = new BufferedReader(new InputStreamReader(
     			openFileInput("Statistika")));
     	String line;
    	 while ((line = input.readLine()) != null) {
 		 	 
 		 	count++;	
 		}
    	}
    	 catch(Exception e)
    	 {
    	    e.printStackTrace();
    	 }
    	
    	return count; 
     }
    
    private List<String> readStatistics()
    {
    	List<String> instat = new ArrayList<String>();
    	
    	String eol = System.getProperty("line.separator");
    	try {
    		BufferedReader input = new BufferedReader(new InputStreamReader(
    			openFileInput("Statistika")));
    		String line;
    		
    		bar = (ProgressBar) findViewById(R.id.progressBar1);
    		
    		bar.setMax(count());
    		
    		while ((line = input.readLine()) != null) {    		 	
    		 	 instat.add(line);
    		 	 i++;
    		 	 bar.setProgress(i);
    		 	Thread.sleep(500); 	
    		}    		 
    		
    	} catch (Exception e) {
    	e.printStackTrace();
    	}
    	
    	return instat;
    }
    
    private Runnable run = new Runnable(){
    	
    	public void run()
    	{
    		readStatistics();   		
    	} 
    };
    	  
	
    
  
}
         


    

