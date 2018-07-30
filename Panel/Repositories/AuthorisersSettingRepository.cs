﻿using Panel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Panel.Repositories
{
    public class AuthorisersSettingRepository : Repository<AuthoriserSetting>,
        IAuthorisersSettingsRepository
    {
        public AuthorisersSettingRepository(GeneratorSurveillanceDBEntities context)
            : base(context) { }

        public GeneratorSurveillanceDBEntities GeneratorSurveillanceDBContext
        {
            get { return Context as GeneratorSurveillanceDBEntities; }
        }

        public void SetAuthorisers(DateTime ReminderDate, string FirstName,
            string LastName, string Email, string PhoneNumber,
            string JobTitle)
        {
            int NoOfRecords = GeneratorSurveillanceDBContext
                                            .AuthoriserSettings
                                            .Count();

            GeneratorSurveillanceDBContext.AuthoriserSettings.Add
            (
                new AuthoriserSetting
                {
                    Id = NoOfRecords,
                    Date = ReminderDate,
                    FirstNameAuthoriser = FirstName,
                    LastNameAuthoriser = LastName,
                    EmailAuthoriser = Email,
                    PhoneNumberAuthoriser = PhoneNumber,
                    JobTitleAuthoriser = JobTitle
                }
            );
        }
        
        public ObservableCollection<AuthoriserSetting> GetAllAuthorisers()
        {
            return new ObservableCollection<AuthoriserSetting>
                (
                    GeneratorSurveillanceDBContext
                    .AuthoriserSettings
                    .AsParallel()
                );
        }

        public List<string> GetAuthorisersFullNames()
        {
            var FullNameList = new List<string>();
            foreach (var authoriser in GeneratorSurveillanceDBContext
                                       .AuthoriserSettings)
            {
                FullNameList.Add($"{authoriser.FirstNameAuthoriser} " +
                    $"{authoriser.LastNameAuthoriser}");
            }
            return FullNameList;
        }

        public List<string> GetAuthorisersEmails()
        {
            var EmailsList = new List<string>();
            foreach (var Authoriser in GeneratorSurveillanceDBContext
                                       .AuthoriserSettings)
            {
                EmailsList.Add(Authoriser.EmailAuthoriser);
            }
            return EmailsList.Distinct().ToList();
        }
    }
}
