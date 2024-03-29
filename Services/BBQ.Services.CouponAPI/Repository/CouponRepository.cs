﻿using AutoMapper;
using BBQ.Services.CouponAPI.DbContexts;
using BBQ.Services.CouponAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BBQ.Services.CouponAPI.Repository;

public class CouponRepository : ICouponRepository
{
    private readonly ApplicationDbContext _db;
    protected IMapper _mapper;
    public CouponRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<CouponDto> GetCouponByCode(string couponCode)
    {
        var couponFromDb = await _db.Coupons.FirstOrDefaultAsync(u => u.CouponCode == couponCode);
        return _mapper.Map<CouponDto>(couponFromDb);
    }
}