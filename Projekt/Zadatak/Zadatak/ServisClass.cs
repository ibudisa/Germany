using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Zadatak
{

     [DataContract]
     public class Response
     {
        [DataMember(Name="res")]
        public RootObject[] res {get;set;}
     }
      
    public class RootObject
    {
        [DataMember(Name="id")]
        public int id { get; set; }
        [DataMember(Name="name")]
        public string name { get; set; }
        [DataMember(Name="username")]
        public string username { get; set; }
        [DataMember(Name="email")]
        public string email { get; set; }
        [DataMember(Name="address")]
        public Address address { get; set; }
        [DataMember(Name="phone")]
        public string phone { get; set; }
        [DataMember(Name="website")]
        public string website { get; set; }
        [DataMember(Name="company")]
        public Company company { get; set; }
    }
    [DataContract]
    public class Company
    {
        [DataMember(Name="name")]
        public string name { get; set; }
        [DataMember(Name="catchPhrase")]
        public string catchPhrase { get; set; }
        [DataMember(Name="bs")]
        public string bs { get; set; }
    }
    [DataContract]
    public class Address
    {
        [DataMember(Name="street")]
        public string street { get; set; }
        [DataMember(Name="suite")]
        public string suite { get; set; }
        [DataMember(Name="city")]
        public string city { get; set; }
        [DataMember(Name="zipcode")]
        public string zipcode { get; set; }
        [DataMember(Name="geo")]
        public Geo geo { get; set; }
    }
    [DataContract]
    public class Geo
    {
        [DataMember(Name="lat")]
        public string lat { get; set; }
        [DataMember(Name="lng")]
        public string lng { get; set; }
    }

}