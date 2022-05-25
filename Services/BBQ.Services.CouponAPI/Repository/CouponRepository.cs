using AutoMapper;
using BBQ.Services.CouponAPI.DbContexts;
using BBQ.Services.CouponAPI.Models.Dto;

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
    public Task<CouponDto> GetCouponByCode(string couponCode)
    {
        throw new NotImplementedException();
    }
}