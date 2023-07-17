using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web_Api_Event_Game.Data;
using Web_Api_Event_Game.Models;

namespace Web_Api_Event_Game.Services.EventServices
{
    public class VoucherService : IVoucherService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VoucherService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
                      
        public async Task<ServiceResponse<List<GetVoucherDTO>>> GetAllVoucher()
        {
            var serviceResponse = new ServiceResponse<List<GetVoucherDTO>>();
            var coupons = await _context.Coupons
                            .ToListAsync();
            serviceResponse.Data = coupons.Select(e => _mapper.Map<GetVoucherDTO>(e)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVoucherDTO>> GetSingleVoucher(int id)
        {
            var serviceResponse = new ServiceResponse<GetVoucherDTO>();
            try
            {
                var getVoucher = await _context.Coupons
                                .Where(e => e.Id == id)
                                .FirstOrDefaultAsync();
                if (getVoucher is null)
                {
                    throw new Exception($"voucher with ID '{id}' not found!!");
                };
                serviceResponse.Data = _mapper.Map<GetVoucherDTO>(getVoucher);
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVoucherDTO>>> AddVoucher( AddVoucherDTOcs NewVoucher)
        {
            var serviceResponse = new ServiceResponse<List<GetVoucherDTO>>();
            var newVoucher = _mapper.Map<Coupon>(NewVoucher);
            try
            {
                var getGame = await _context.Games
                                .Where(e => e.GameId == NewVoucher.GameId)
                                .FirstOrDefaultAsync();
                if (getGame is null)
                {
                    throw new Exception($"Game with ID '{NewVoucher.GameId}' not found!!");
                };
                var voucher = new Coupon
                {
                    GameId = NewVoucher.GameId,
                    Code = NewVoucher.Code,
                    Name = NewVoucher.Name,
                   Discount = NewVoucher.Discount,
                   UserId = NewVoucher.UserId,
                   EventId = NewVoucher.EventId,
                };
                _context.Coupons.Add(voucher);
                await _context.SaveChangesAsync();
                var vouchers = await _context.Coupons.ToListAsync();
                serviceResponse.Data = vouchers.Select(e => _mapper.Map<GetVoucherDTO>(e)).ToList();

            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVoucherDTO>> UpdateVoucher(int id, AddVoucherDTOcs UpdateVoucher)
        {
            var serviceResponse = new ServiceResponse<GetVoucherDTO>();
            try
            {
                var getvoucher = await _context.Coupons.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception($"Voucher with ID '{id}' not found!!");
                getvoucher.Name = UpdateVoucher.Name;
                getvoucher.Code = UpdateVoucher.Code;
                getvoucher.UserId = UpdateVoucher.UserId;
                getvoucher.Discount = UpdateVoucher.Discount;
                getvoucher.EventId = UpdateVoucher.EventId;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetVoucherDTO>(getvoucher);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVoucherDTO>>> DeleteVoucher(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetVoucherDTO>>();
            try
            {
                var VoucherExist = await _context.Coupons.FirstOrDefaultAsync(e => e.Id == id);
                if (VoucherExist == null)
                {
                    throw new Exception($"Voucher with ID '{id}' not found!!");
                }
                _context.Coupons.Remove(VoucherExist);
                await _context.SaveChangesAsync();
                var vouchers = await _context.Coupons.ToListAsync();
                serviceResponse.Data = vouchers.Select(e => _mapper.Map<GetVoucherDTO>(e)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;
        }



      
    }
}
