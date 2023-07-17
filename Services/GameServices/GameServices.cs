using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web_Api_Event_Game.Data;

namespace Web_Api_Event_Game.Services.GameServices
{
    public class GameServices :IGameServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GameServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Game
        public async Task<ServiceResponse<List<GetGameDTO>>> AddGame(AddGameDTO NewGame)
        {
            var serviceResponse = new ServiceResponse<List<GetGameDTO>>();
            var newGame = _mapper.Map<Game>(NewGame);
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            var events = await _context.Games.ToListAsync();
            serviceResponse.Data = events.Select(e => _mapper.Map<GetGameDTO>(e)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGameDTO>>> DeleteGame(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGameDTO>>();
            try
            {
                var GameExist = await _context.Games.FirstOrDefaultAsync(e => e.GameId == id);
                if (GameExist == null)
                {
                    throw new Exception($"Game with ID '{id}' not found!!");
                }
                _context.Games.Remove(GameExist);
                await _context.SaveChangesAsync();
                var games = await _context.Games.ToListAsync();
                serviceResponse.Data = games.Select(e => _mapper.Map<GetGameDTO>(e)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGameDTO>>> GetAllGame()
        {
            var gamesWithEvents = await _context.Games                                    
                                    .ToListAsync();

            var gameDtos = gamesWithEvents.Select(g => new GetGameDTO
            {
                GameId = g.GameId,
                Name = g.Name,    
                Description = g.Description,
            }).ToList();
            var serviceResponse = new ServiceResponse<List<GetGameDTO>>
            {                Data = gameDtos
            };
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<GetGameVoucherDTO>> GetSingleGame(int id)
        {
            var serviceResponse = new ServiceResponse<GetGameVoucherDTO>();
            try
            {
                var getGame = await _context.Games
                                .Where(e => e.GameId == id)
                                .Include(e => e.Coupons)                                
                                .FirstOrDefaultAsync();
                if (getGame is null)
                {
                    throw new Exception($"Event with ID '{id}' not found!!");
                };
                var eventGameDtos = new GetGameVoucherDTO
                {
                    GameId = getGame.GameId,
                    Name = getGame.Name,
                    Description= getGame.Description,
                    Coupons = getGame.Coupons!.Select(e => new GetVoucherDTO
                    {
                        GameId= (int)e.GameId!,
                        Name = e.Name,
                        Code = e.Code,
                        Id  = e.Id,
                        Discount = e.Discount,
                        UserId = e.UserId,
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

        public async Task<ServiceResponse<GetGameDTO>> UpdateGame(int id, AddGameDTO UpdateGame)
        {
            var serviceResponse = new ServiceResponse<GetGameDTO>();
            try
            {
                var getGame = await _context.Games.FirstOrDefaultAsync(e => e.GameId == id) ?? throw new Exception($"Game with ID '{id}' not found!!");
                getGame.Name = UpdateGame.Name;
                getGame.Description = UpdateGame.Description;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetGameDTO>(getGame);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


    }
}
