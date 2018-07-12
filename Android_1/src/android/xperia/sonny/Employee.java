package android.xperia.sonny;

public class Employee {
	
	private int id;
	private String name;
	private int age;
	
	
	public int getId()
	{
		return this.id;
	}
    
	public void setId(int _id)
	{
		this.id=_id;
	}
	public String getName()
	{
		return this.name;
	}
	
	public void setName(String _name)
	{
		this.name=_name;
	}

    public int getAge()
	{
		return this.age;
	}
	public void setAge(int _age)
	{
		this.age=_age;
	}
	 public String ToString()
	 {
		 return this.id+" "+this.name+" "+this.age;
	 }
}
