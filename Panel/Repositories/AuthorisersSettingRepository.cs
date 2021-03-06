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
            AuthoriserSetting authoriserSetting 
                            = GeneratorSurveillanceDBContext
                            .AuthoriserSettings
                            .OrderByDescending(x => x.SN)
                            .FirstOrDefault();

            int RecordNo = GeneratorSurveillanceDBContext.AuthoriserSettings
                .OrderByDescending(x => x.Id).Select(x => x.Id).ToArray()[0];

            int SNNo = GeneratorSurveillanceDBContext.AuthoriserSettings
               .OrderByDescending(x => x.SN).Select(x => x.SN).ToArray()[0];


            GeneratorSurveillanceDBContext.AuthoriserSettings.Add
            (
                new AuthoriserSetting
                {
                    Id = RecordNo + 1,
                    SN = SNNo + 1,
                    Date = ReminderDate,
                    FirstNameAuthoriser = FirstName,
                    LastNameAuthoriser = LastName,
                    EmailAuthoriser = Email,
                    PhoneNumberAuthoriser = PhoneNumber,
                    JobTitleAuthoriser = JobTitle
                }
            );
        }

        public void DeleteAuthoriser(string FirstName, string LastName)
        {
            foreach (var item in GeneratorSurveillanceDBContext
                                  .AuthoriserSettings
                                  .Where(x => x.SN >= 0))
            {
                if (item.FirstNameAuthoriser == FirstName &&
                    item.LastNameAuthoriser == LastName)
                {
                    GeneratorSurveillanceDBContext
                        .AuthoriserSettings
                        .Remove(item);
                }
            }
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
