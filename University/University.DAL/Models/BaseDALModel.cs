﻿namespace University.DAL.Models
{
    public interface BaseDALModel<IdType>
    {
        public IdType Id { get; set; }
    }
}
