﻿using SailingAppClean.Application.Common.Interfaces;
using SaillingAppClean.Infrastructure.Data;

namespace SaillingAppClean.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IShipRepository Ship { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Ship = new ShipRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
