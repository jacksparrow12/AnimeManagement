﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class RemoveFullPathFromFolder
    {

        public static string getFolder(string path)
        {
            char[] delim = { '\\' };
            return path.Split(delim).Last();
        }
    }
