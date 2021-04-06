using System;

namespace QuanLyKho.dao
{
    class Employee
    {
        public string username { get => username; set => username = value; }
        public string password { get => password; set => password = value; }
        public string code { get => code; set => code = value; }
        public string name { get => name; set => name = value; }
        public DateTime dob { get => dob; set => dob = value; }
        public bool gender { get => gender; set => gender = value; }
        public string phoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime dayOne { get => dayOne; set => dayOne = value; }
        public string identity { get => identity; set => identity = value; }

        public Employee(string username, string password, string code, string name, DateTime dob, bool gender, string phoneNumber, DateTime dayOne, string identity)
        {
            this.username = username;
            this.name = name;
            this.password = password;
            this.code = code;
            this.dob = dob;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.dayOne = dayOne;
            this.identity = identity;
        }

        public Employee()
        {

        }


    }
}
