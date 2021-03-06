﻿using Panel.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Panel.Repositories
{
    public class GeneratorUsageRepository : Repository<GeneratorUsage>, 
        IGeneratorUsageRepository
    {
        public GeneratorUsageRepository(GeneratorSurveillanceDBEntities context) 
            : base(context)
        {
            
        }

        public GeneratorSurveillanceDBEntities GeneratorSurveillanceDBContext
        {
            get { return Context as GeneratorSurveillanceDBEntities; }
        }

        
        public void GeneratorStarted(DateTime RecordDate, string GeneratorName, 
            DateTime GeneratorStarted)
        {
            int RecordNo = GeneratorSurveillanceDBContext.GeneratorUsages
                .OrderByDescending(x => x.Id).Select(x => x.Id).ToArray()[0];

            int SNNo = GeneratorSurveillanceDBContext.GeneratorUsages
                .OrderByDescending(x => x.SN).Select(x => x.SN).ToArray()[0];

            GeneratorSurveillanceDBContext.GeneratorUsages.Add
            (
                new GeneratorUsage
                {
                    Id = RecordNo + 1,
                    SN = SNNo + 1,
                    Date = RecordDate,
                    GeneratorName = GeneratorName,
                    GeneratorStarted = GeneratorStarted,
                    IsArchived = "No"
                }
            );
        }

        public void GeneratorStopped(DateTime GeneratorStoppedDate, int ActiveGenID)
        {
            var LastGeneratorUsageRecord = GeneratorSurveillanceDBContext.GeneratorUsages
                                            .SingleOrDefault(x => x.SN == ActiveGenID);

            LastGeneratorUsageRecord.GeneratorStopped = GeneratorStoppedDate;
        }

        public ObservableCollection<GeneratorUsage> GetAllGeneratorUsages()
        {
            var AllGeneratorUsages = new ObservableCollection<GeneratorUsage>
                (
                    GeneratorSurveillanceDBContext
                    .GeneratorUsages
                    .AsParallel<GeneratorUsage>() 
                );

            return AllGeneratorUsages;
        }

        public ObservableCollection<GeneratorUsage> GetFirstPageGeneratorUsages()
        {
            var FirstPageGeneratorUsages = new ObservableCollection<GeneratorUsage>
                                            (
                                                GeneratorSurveillanceDBContext
                                                .GeneratorUsages
                                                .Take(10)
                                                .AsParallel<GeneratorUsage>()
                                            );
            return FirstPageGeneratorUsages;
        }

        public ObservableCollection<GeneratorUsage> GetAnyPageGeneratorUsages(
            int pageIndex = 1, int pageSize = 10)
        {
            int RecordNo = GeneratorSurveillanceDBContext.GeneratorUsages.Count();
            var NextPageLastRowNumber = pageIndex * pageSize;
            int SkipBy = (pageIndex == 1) ? (pageIndex - 1) * pageSize 
                                          : ((pageIndex - 1) * pageSize) - 1;
            if ((RecordNo - NextPageLastRowNumber) > pageSize)
            {
                return new ObservableCollection<GeneratorUsage>
                        (
                            GeneratorSurveillanceDBContext.GeneratorUsages
                            .OrderBy(x => x.SN)
                            .Skip(SkipBy)
                            .Take(pageSize)
                            .AsParallel<GeneratorUsage>()
                        );

            }
            else
            {
                return new ObservableCollection<GeneratorUsage>
                        (
                            GeneratorSurveillanceDBContext.GeneratorUsages
                            .OrderBy(x => x.SN)
                            .Skip(SkipBy)
                            .Take(pageSize)
                            .AsParallel<GeneratorUsage>()
                        );
            }
        }

        
        public DateTime GetStartedDate(string GeneratorName)
        {
            var genFirstStartedDate = GeneratorSurveillanceDBContext
                                            .GeneratorUsages
                                            .FirstOrDefault(x => x.GeneratorName == GeneratorName)
                                            .Date;
            return genFirstStartedDate;
        }

        public DateTime GetStoppedDate(string GeneratorName)
        {
            DateTime genLastStoppedDate = GeneratorSurveillanceDBContext
                                            .GeneratorUsages
                                            .OrderByDescending(x => x.Date)
                                            .Where(x => x.GeneratorName == GeneratorName)
                                            .Select(x => x.Date)
                                            .FirstOrDefault();
            return genLastStoppedDate;
        }

        public DateTime GetStartedTime(string GeneratorName)
        {
            var genFirstStartedTime = GeneratorSurveillanceDBContext
                                            .GeneratorUsages
                                            .FirstOrDefault(x => x.GeneratorName == GeneratorName)
                                            .GeneratorStarted;
            return genFirstStartedTime;
        }

        public DateTime GetStoppedTime(string GeneratorName)
        {
            DateTime genLastStoppedTime = GeneratorSurveillanceDBContext
                                            .GeneratorUsages
                                            .OrderByDescending(x => x.Date)
                                            .Where(x => x.GeneratorName == GeneratorName)
                                            .Select(x => x.GeneratorStopped)
                                            .FirstOrDefault();
            return genLastStoppedTime;
        }
    }
}
