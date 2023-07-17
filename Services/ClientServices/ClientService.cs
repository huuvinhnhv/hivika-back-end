using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web_Api_Event_Game.Data;
using Web_Api_Event_Game.Models;

namespace Web_Api_Event_Game.Services.EventServices
{
    public class ClientService : IClientService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClientService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //ClientServices

        public async Task<ServiceResponse<List<GetClientDTO>>> GetAllClient()
        {
            var serviceResponse = new ServiceResponse<List<GetClientDTO>>();
            var clients = await _context.Clients
                            .Include(c=>c.Events)!                            
                             .ThenInclude(c=>c.EventGames)                             
                            .ToListAsync();
            serviceResponse.Data = clients.Select(e => _mapper.Map<GetClientDTO>(e)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientDTO>> GetSingleClient(int id)
        {
            var serviceResponse = new ServiceResponse<GetClientDTO>();
            try
            {
                var getClient = await _context.Clients
                                .Where(e => e.ClientId == id)
                                .Include(e => e.Events)!
                                .ThenInclude(e => e.EventGames)
                                .FirstOrDefaultAsync();
                if (getClient is null)
                {
                    throw new Exception($"Client with ID '{id}' not found!!");
                };
                serviceResponse.Data = _mapper.Map<GetClientDTO>(getClient);
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClientDTO>>> AddClient(AddClientDTO NewClient)
        {
            var serviceResponse = new ServiceResponse<List<GetClientDTO>>();
            var newClient = _mapper.Map<Client>(NewClient);
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
            var clients = await _context.Clients.ToListAsync();
            serviceResponse.Data = clients.Select(e => _mapper.Map<GetClientDTO>(e)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientDTO>> UpdateClient(int id, AddClientDTO UpdateClient)
        {
            var serviceResponse = new ServiceResponse<GetClientDTO>();
            try
            {
                var getClient = await _context.Clients.FirstOrDefaultAsync(e => e.ClientId == id) ?? throw new Exception($"Client with ID '{id}' not found!!");
                getClient.ClientName = UpdateClient.ClientName;
                getClient.Address = UpdateClient.Address;
                getClient.PhoneNumber = UpdateClient.PhoneNumber;
                getClient.Description = UpdateClient.Description;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetClientDTO>(getClient);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClientDTO>>> DeleteClient(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetClientDTO>>();
            try
            {
                var ClientExist = await _context.Clients.FirstOrDefaultAsync(e => e.ClientId == id);
                if (ClientExist == null)
                {
                    throw new Exception($"Client with ID '{id}' not found!!");
                }
                _context.Clients.Remove(ClientExist);
                await _context.SaveChangesAsync();
                var clients = await _context.Clients.ToListAsync();
                serviceResponse.Data = clients.Select(e => _mapper.Map<GetClientDTO>(e)).ToList();
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
