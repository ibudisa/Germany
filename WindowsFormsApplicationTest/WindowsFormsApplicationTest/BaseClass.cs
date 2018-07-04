using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.IO;

namespace WindowsFormsApplicationTest
{
    public class BaseClass<T> : IBase<T> where T:class
    {
        PropertyInfo[] myPropertyInfo = typeof(T).GetProperties();
        T value;
        string filename = typeof(T).FullName;
        public string Id
        {
           get
            {
                string v = typeof(T).GetProperty("Id").GetValue(value, null).ToString();
                return v;
            }
            set { }
        }

        
        public BaseClass()
        {
            
        }

        public BaseClass(params object[] values)
        {
            int i = 0;
            try
            {
                value = Activator.CreateInstance<T>();
                foreach (var property in myPropertyInfo)
                {
                    if (property.Name != "Id")
                    {
                        property.SetValue(this, Convert.ChangeType(values[i], property.PropertyType), null);
                         i++;
                    }
                }
            }
            catch(Exception ec)
            {

            }
        }



        public static List<T> GetAll()
        {
            BaseClass<T> c = new BaseClass<T>();
            string file = c.GetFile();
            string value;
            int id = 0;
            int i = 0;

            T v = default(T);
            List<T> list = new List<T>();
            
            using (StreamReader reader = (File.Exists(file) ? File.OpenText(file) : new StreamReader(File.Create(file))))
            {

                  while ((value = reader.ReadLine()) != null)
                  {
                        if(id==0)
                        {
                          v = Activator.CreateInstance<T>();
                        }
                        if (value == string.Empty)
                        {
                            v = Activator.CreateInstance<T>();
                        i = 0;
                        continue;
                        }
                        id++;
                        string[] array1 = value.Split('-');
                        string typename = array1[0];
                        //Type a = Type.GetType(typename);
                        string[] array2 = array1[1].Split(':');
                        if (!(typename == "WindowsFormsApplicationTest.Address"))
                        {

                            Type fieldtype = Type.GetType(typename);
                            string fieldname = array2[0];
                            string fieldvalue = array2[1];

                            if (c.myPropertyInfo[i].Name == fieldname)
                            {
                                c.myPropertyInfo[i].SetValue(v, Convert.ChangeType(fieldvalue, fieldtype), null);

                            }

                        }

                        else
                        {
                            string[] array3 = array2[1].Split(',');
                            string[] array4 = array3[0].Split('=');
                            string[] array5 = array3[1].Split('=');
                            string[] array6 = array3[2].Split('=');
                            string[] array7 = array3[3].Split('=');

                            string addressname = array4[1];
                            string city = array5[1];
                            string code = array6[1];
                            string zipcode = array7[1];

                            Address address = new Address(addressname, city, code, zipcode);


                            if (c.myPropertyInfo[i].PropertyType.FullName == "WindowsFormsApplicationTest.Address")
                            {
                                c.myPropertyInfo[i].SetValue(v, address,null);
                            }

                        }

                    if (i == c.myPropertyInfo.Length - 1)
                    {
                        list.Add(v);
                    }

                    i++;
                }
                      
            }
            return list;
        }

        public void Delete()
        {
            string file = GetFile();
            PropertyInfo[] properties = typeof(T).GetProperties();
            string id=String.Empty;
            string value;
            bool replace = false;
            List<string> lines = new List<string>();

            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {                 
                   id = typeof(T).GetProperty(property.Name).GetValue(this, null).ToString();        
                }
            }

            using (StreamReader reader = (File.Exists(file) ? File.OpenText(file) : new StreamReader(File.Create(file))))
            {

                while ((value = reader.ReadLine()) != null)
                {
                   
                    if (value == String.Empty)
                    {
                        break;
                    }
                    

                    string[] a = value.Split('-');
                    string[] b = a[1].Split(':');
                    
                       
                    if (b[0] == "Id")
                    {
                        typeof(T).GetProperty("Id").SetValue(this, "", null);
                        string num = b[1];

                        if (num == id)
                        {
                            lines.Add(string.Empty); 
                            
                            replace = true;
                            continue;
                        }
                    }
                    if(!replace)
                    {
                        lines.Add(value);
                    }
                    if (replace && value != string.Empty)
                    {

                        lines.Add(string.Empty);

                            continue;
                    }
                    if (value == string.Empty)
                    {
                        replace = false;
                    }

                
            }
               
            }

            OverWriteFile(lines);
             
        }

        public void OverWriteFile(List<string> data)
        {
            string file = GetFile();

            using (StreamWriter writer = new StreamWriter(file))
            {
                
                foreach(var item in data)
                {
                    writer.WriteLine(item);
                }
               
            }
        }

        public static T Find(string id)
        {
            List<T> data = GetAll();
            T r = default(T);
            PropertyInfo[] properties = typeof(T).GetProperties();
            int index=int.Parse(id);

            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {
                    foreach (var item in data)
                    {
                        string a = typeof(T).GetProperty(property.Name).GetValue(item, null).ToString();
                        int v = int.Parse(a);
                        if(v==index)
                        {
                            r = item;
                        }
                    }
                }
            }
            return r;
        }

     
        public void Save()
        {
            string data;
            string h;
            int num = 0;
            string file = GetFile();

            num = MaxId();

            using (StreamWriter writer = (File.Exists(file) ? File.AppendText(file) : File.CreateText(file)))
            {
                try
                {
                    foreach (var property in myPropertyInfo)
                    {
                        if (property.Name != "Id")
                        {
                            data = typeof(T).GetProperty(property.Name).GetValue(this, null).ToString();
                            h = property.PropertyType.FullName + "-" + property.Name + ":" + data;
                            writer.WriteLine(h);
                        }
                        else
                        {

                            num++;
                            typeof(T).GetProperty(property.Name).SetValue(this, num.ToString(), null);
                           // Id = num.ToString();
                            h = "System.String-Id:" + num.ToString();
                            writer.WriteLine(h);
                        }
                    }
                }
                catch(Exception ec)
                {

                }

                writer.WriteLine();
            }

        }

        public string GetFile()
        {
            string folder = @"C:\Text\";
            CreateFolder(folder);
            string file = folder + filename + ".txt";
            return file;
        }

        private void CreateFolder(string folder)
        {
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public bool CheckFile(string file)
        {
            if (!File.Exists(file))
            {           
                return false;
            }
            return true;
        }

        public int MaxId()
        {
            string file = GetFile();
            string value;
            int id = 0;
            int maxid = 0;

            using (StreamReader reader = (File.Exists(file) ? File.OpenText(file) : new StreamReader(File.Create(file))))
            {
                while ((value = reader.ReadLine()) != null)
                {
                    if(value==String.Empty)
                    {
                        break;
                    }
                    string[] a = value.Split('-');
                    string[] b = a[1].Split(':');
                    if (b[0] == "Id")
                    {
                        string num = b[1];
                        id = int.Parse(num);
                        if (id > maxid)
                        {
                            maxid = id;
                        }
                    }
                }
            }
            return maxid;
        }

        public override int GetHashCode()
        {
            PropertyInfo[] theProperties = this.GetType().GetProperties();
            int hash = 31;
            foreach (PropertyInfo info in theProperties)
            {
                if (info != null && info.Name!="Id")
                {
                    var value = info.GetValue(this, null);
                    if (value != null)
                        unchecked
                        {
                            hash = 29 * hash ^ value.GetHashCode();
                        }
                }
            }
            return hash;
        }

       public override bool Equals(object obj)
       {
            bool b = false;
            T other;
            PropertyInfo[] theProperties = this.GetType().GetProperties();
             
            if (obj is T)
            {
                other = obj as T;
                foreach (PropertyInfo info in theProperties)
                {
                    if (info != null)
                    {
                        var value = info.GetValue(this, null);
                        var othervalue = info.GetValue(other, null);
                        if (value != null && othervalue!=null)
                        {
                            if(value.Equals(othervalue))
                            {
                                b = true;
                            }
                        }
                          
                    }
                }
            }
            return b;
       }

        
    }
}
