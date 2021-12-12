using AutoMapper;
using BLL.DTO;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BLL.Services.Impl
{
    public class VoteService : IVoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VoteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("UnitOfWork shouldn't be null");
            if (mapper == null)
                throw new ArgumentNullException("Mapper shouldn't be null");

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(VoteDTO model)
        {
            if (!Validate(model, out var results))
                throw new ValidationException(string.Join("\n", results.Select(r => r.ErrorMessage)));

            var vote = _mapper.Map<Vote>(model);

            _unitOfWork.Votes.Create(vote);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Votes.Delete(id);
            _unitOfWork.Save();
        }

        public VoteDTO Get(int id)
        {
            var vote = _unitOfWork.Votes.Get(id);
            var voteDTO = _mapper.Map<VoteDTO>(vote);

            return voteDTO;
        }

        public IEnumerable<VoteDTO> GetAll()
        {
            var vote = _unitOfWork.Votes.GetAll();
            var driverDTOs = _mapper.Map<IEnumerable<VoteDTO>>(vote);

            return driverDTOs;
        }

        public void Update(VoteDTO model)
        {
            var vote = _mapper.Map<Vote>(model);
            _unitOfWork.Votes.Update(vote);
            _unitOfWork.Save();
        }

        private bool Validate(VoteDTO obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new System.ComponentModel.DataAnnotations.ValidationContext(obj), results, true);
        }
    }
}
