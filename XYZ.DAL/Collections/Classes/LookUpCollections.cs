﻿using XYZ.DAL.Collections.Interfaces;
using XYZ.DAL.DBContext;
using XYZ.DAL.Models;

namespace XYZ.DAL.Collections.Classes
{

    public class TagStatusCollection : BaseCollection<TagStatus, IDbContext>, ITagStatusCollection
    {

    }
   
}