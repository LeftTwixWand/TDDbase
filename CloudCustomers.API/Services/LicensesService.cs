﻿

using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services;

public class LicensesService : ILicensesService
{
   
    public LicensesService(ILicensesService licensesService)
    {
       
    }

    public Task<List<License>> GetAllLicenses()
    {
        throw new NotImplementedException();
    }
    
}