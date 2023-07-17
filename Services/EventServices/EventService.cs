using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Web_Api_Event_Game.Data;
using Web_Api_Event_Game.Models;

namespace Web_Api_Event_Game.Services.EventServices
{
    public class EventService : IEventService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetEventDTO>>> AddEvent(AddEventDTO NewEvent)
        {
            var serviceResponse = new ServiceResponse<List<GetEventDTO>>();
            try
            {
                var getClient = await _context.Clients
                                .Where(e => e.ClientId == NewEvent.ClientId)                                
                                .FirstOrDefaultAsync() ?? throw new Exception($"Client with ID '{NewEvent.ClientId}' not found!!");
                ;
                var newEvent = new Event
                {
                    Name = NewEvent.Name,
                    StartDate = NewEvent.StartDate,
                    EndDate = NewEvent.EndDate,
                    ClientId = NewEvent.ClientId,
                    Description = NewEvent.Description
                };
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();
                var events = await _context.Events.ToListAsync();
                serviceResponse.Data = events.Select(e => _mapper.Map<GetEventDTO>(e)).ToList();
                return serviceResponse;
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;           

        }

        public async Task<ServiceResponse<List<GetEventDTO>>> DeleteEvent(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetEventDTO>>();
            try
            {
                var EventExist = await _context.Events.FirstOrDefaultAsync(e => e.EventId == id);
                if (EventExist == null)
                {
                    throw new Exception($"Event with ID '{id}' not found!!");
                }
                _context.Events.Remove(EventExist);
                await _context.SaveChangesAsync();
                var events = await _context.Events.ToListAsync();
                serviceResponse.Data = events.Select(e => _mapper.Map<GetEventDTO>(e)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEventDTO>>> GetAllEvents()
        {

            var events= await _context.Events                                    
                                    .ToListAsync();

            var eventDtos = events.Select(e => new GetEventDTO
            {
                EventId = e.EventId,
                Name = e.Name,
                StartDate = e.StartDate,   
                EndDate = e.EndDate,
                ClientId = (int)e.ClientId!,
                Description = e.Description,               
            }).ToList();
            var serviceResponse = new ServiceResponse<List<GetEventDTO>>
            {
                Data = eventDtos
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEventGameDTOcs>> GetSingleEvent(int id)
        {
            var serviceResponse = new ServiceResponse<GetEventGameDTOcs>();
            try
            {
                var getEvent = await _context.Events
                                .Where(e => e.EventId == id).Include(e => e.EventGames)!.ThenInclude(eg => eg.Game).FirstOrDefaultAsync();
                if (getEvent is null)
                {
                    throw new Exception($"Event with ID '{id}' not found!!");
                };
                var eventGameDtos = new GetEventGameDTOcs
                {
                    EventId = getEvent.EventId,
                    Name= getEvent.Name,
                    ClientId = (int)getEvent.ClientId!,
                    Description = getEvent.Description,
                    StartDate = getEvent.StartDate,
                    EndDate = getEvent.EndDate,
                    Games = getEvent.EventGames!.Select(e => new GetGameDTO
                    {
                        Name = e.Game.Name,
                        GameId = e.GameId,
                        Description = e.Game.Description,
                    }).ToList(),
                };
                serviceResponse.Data = eventGameDtos;
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEventDTO>> UpdateEvent(int id, AddEventDTO UpdateEvent)
        {
            var serviceResponse = new ServiceResponse<GetEventDTO>();
            try
            {
                var getEvent = await _context.Events.FirstOrDefaultAsync(e => e.EventId == id) ?? throw new Exception($"Event with ID '{id}' not found!!");
                getEvent.Name = UpdateEvent.Name;
                getEvent.ClientId = UpdateEvent.ClientId;
                getEvent.Description = UpdateEvent.Description;
                getEvent.StartDate = UpdateEvent.StartDate;
                getEvent.EndDate = UpdateEvent.EndDate;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetEventDTO>(getEvent);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        //AddGametoEvent
        public async Task<ServiceResponse<GetEventGameDTOcs>> AddGameToEvent(AddGameToEventDTO GameEvent)
        {
            var serviceResponse = new ServiceResponse<GetEventGameDTOcs>();
            var newGameEvent = _mapper.Map<EventGame>(GameEvent);
            try
            {
                var getGame = await _context.Games
                                .Where(e => e.GameId == GameEvent.GameId)
                                .FirstOrDefaultAsync();
                var getEvent = await _context.Events
                                .Where(e => e.EventId == GameEvent.EventId)
                                .FirstOrDefaultAsync();
                if (getGame == null || getEvent == null)
                {
                    throw new Exception($"Game or Event  with GameID '{GameEvent.GameId}' or EventID '{GameEvent.EventId}'  not found!!");
                }
                _context.EventGames.Add(newGameEvent);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetEventGameDTOcs>(newGameEvent);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;
        }

        public async  Task<ServiceResponse<List<EventGame>>> GetAllGameEvent()
        {
            var eventGames = await _context.EventGames
                                   .ToListAsync();
            var serviceResponse = new ServiceResponse<List<EventGame>>
            {
                Data = eventGames
            };
            return serviceResponse;
        }
    }
}
