﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;


namespace sharpAdvising
{
    

    public class Program
    {
        static void Main(string[] args)
        {

            SQLHANDLER.start();
            PreReq wow = new PreReq();
            TimeFilter test = new TimeFilter(3);
            Console.WriteLine("sdf");
          
        }
    }
}

