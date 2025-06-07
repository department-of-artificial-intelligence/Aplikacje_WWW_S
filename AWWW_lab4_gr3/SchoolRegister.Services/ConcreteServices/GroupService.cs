using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService : BaseService, IGroupService
    {
        private readonly UserManager<User> _userManager;  

        public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger<GroupService> logger, UserManager<User> userManager)
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        // Metoda do dodawania lub aktualizowania grupy
        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            try
            {
                if (addOrUpdateGroupVm == null)
                {
                    Logger.LogError("AddOrUpdateGroupVm is null.");
                    throw new ArgumentNullException(nameof(addOrUpdateGroupVm), "Group data cannot be null.");
                }

                // Sprawdzenie unikalności nazwy grupy (jeśli to wymagane)
                if (DbContext.Groups.Any(g => g.Name == addOrUpdateGroupVm.Name && g.Id != addOrUpdateGroupVm.Id))
                {
                    Logger.LogWarning($"Group with name '{addOrUpdateGroupVm.Name}' already exists.");
                    throw new InvalidOperationException($"Group with name '{addOrUpdateGroupVm.Name}' already exists.");
                }

                Group groupEntity;
                if (addOrUpdateGroupVm.Id > 0) // Aktualizacja
                {
                    groupEntity = DbContext.Groups.Find(addOrUpdateGroupVm.Id);
                    if (groupEntity == null)
                    {
                        Logger.LogWarning($"Group with Id {addOrUpdateGroupVm.Id} not found for update.");
                        throw new InvalidOperationException($"Group with Id {addOrUpdateGroupVm.Id} not found.");
                    }
                    // Mapowanie na istniejącą encję
                    Mapper.Map(addOrUpdateGroupVm, groupEntity);
                }
                else // Dodawanie nowej
                {
                    groupEntity = Mapper.Map<Group>(addOrUpdateGroupVm);
                    DbContext.Groups.Add(groupEntity);
                }

                DbContext.SaveChanges();

                // Mapowanie z powrotem na GroupVm
                // Pobieramy grupę z Include, aby mieć dane dla Students i Subjects w GroupVm
                var createdOrUpdatedEntity = DbContext.Groups
                                                 .Include(g => g.Students)
                                                 .Include(g => g.SubjectGroups)
                                                    .ThenInclude(sg => sg.Subject)
                                                        .ThenInclude(s => s.Teacher) // Aby mieć TeacherName w SubjectVm
                                                 .FirstOrDefault(g => g.Id == groupEntity.Id);
                                                 
                return Mapper.Map<GroupVm>(createdOrUpdatedEntity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in AddOrUpdateGroup: {ex.Message}");
                throw;
            }
        }

        // Metoda do pobierania pojedynczej grupy
        public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                {
                    Logger.LogError("Filter predicate is null in GetGroup.");
                    throw new ArgumentNullException(nameof(filterPredicate), "Filter predicate cannot be null.");
                }

                var groupEntity = DbContext.Groups
                                        .Include(g => g.Students) // Załaduj studentów grupy
                                        .Include(g => g.SubjectGroups) // Załaduj powiązania z przedmiotami
                                            .ThenInclude(sg => sg.Subject) // Załaduj same przedmioty
                                                .ThenInclude(s => s.Teacher) // Dla TeacherName w SubjectVm
                                        .FirstOrDefault(filterPredicate);

                return Mapper.Map<GroupVm>(groupEntity); // AutoMapper zmapuje null na null, jeśli nie znaleziono
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in GetGroup: {ex.Message}");
                throw;
            }
        }

        // Metoda do pobierania listy grup
        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>>? filterPredicate = null)
        {
            try
            {
                var query = DbContext.Groups
                                    .Include(g => g.Students)
                                    .Include(g => g.SubjectGroups)
                                        .ThenInclude(sg => sg.Subject)
                                            .ThenInclude(s => s.Teacher)
                                    .AsQueryable();

                if (filterPredicate != null)
                {
                    query = query.Where(filterPredicate);
                }

                var groupEntities = query.ToList();
                return Mapper.Map<IEnumerable<GroupVm>>(groupEntities);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in GetGroups: {ex.Message}");
                throw;
            }
        }

        // Implementacje metod Attach/Detach dodamy w następnym kroku
        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm vm)
        {
            throw new NotImplementedException();
        }

        public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm vm)
        {
            throw new NotImplementedException();
        }

        public SubjectVm AttachSubjectToGroup(AttachDetachSubjectToGroupVm vm)
        {
            throw new NotImplementedException();
        }

        public SubjectVm DetachSubjectFromGroup(AttachDetachSubjectToGroupVm vm)
        {
            throw new NotImplementedException();
        }

        public SubjectVm AttachTeacherToSubject(AttachDetachTeacherToSubjectVm vm)
        {
            // Ta metoda wydaje się dziwnie umiejscowiona w GroupService.
            // Zazwyczaj przypisanie nauczyciela do przedmiotu to aktualizacja encji Subject.
            // Ale trzymamy się diagramu.
            throw new NotImplementedException();
        }

        public SubjectVm DetachTeacherFromSubject(AttachDetachTeacherToSubjectVm vm)
        {
            // Podobnie jak wyżej.
            throw new NotImplementedException();
        }
    }
}