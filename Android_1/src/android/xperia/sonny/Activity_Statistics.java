package android.xperia.sonny;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class Activity_Statistics extends Activity {
	
	private List<String> izmjene = new ArrayList<String>();
 

	 public void onCreate(Bundle savedInstanceState) {
	        super.onCreate(savedInstanceState);
	        //requestWindowFeature(Window.FEATURE_PROGRESS);
	        setContentView(R.layout.third);
	        

			Bundle extras = getIntent().getExtras();
			if (extras == null) {
				return;
			}
			
			for(String key:extras.keySet())
			{
			  izmjene.add( extras.getString(key));
			}
			
			TextView txtAdd = (TextView)findViewById(R.id.txtAdded);
			TextView txtDel = (TextView)findViewById(R.id.txtDeleted);
			TextView txtChg = (TextView)findViewById(R.id.txtChanged);
			
			
			txtAdd.setText(new Integer(brojPromjena()[2]).toString());
			txtDel.setText(new Integer(brojPromjena()[0]).toString());
			txtChg.setText(new Integer(brojPromjena()[1]).toString());
			
			Button btn = (Button)findViewById(R.id.button2);
			
			btn.setOnClickListener(new View.OnClickListener() {
				
				@Override
				public void onClick(View v) {
					
					finish();
					
				}
			});
			
	 }
	        
	 public int[]  brojPromjena()
	 {
		 int i=0,j=0,k=0
		 ;
		 int[] rez= new int[3];
		 
		 for(String f:izmjene)
		 {
			  if("deleted".equals(f))
				  i++;
			  else if ("updated".equals(f))
				  j++;
			  else if ("inserted".equals(f))
				  k++;
		 }
		 
		 rez[0]=i;
		 rez[1]=j;
		 rez[2]=k;
		 
		 return rez;
	 }
	 
	  
	        
}