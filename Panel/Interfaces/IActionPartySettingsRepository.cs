﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Panel.Interfaces
{
    public interface IActionPartySettingsRepository
    {
        void SetActionParties(DateTime ReminderDate, string FirstName,
            string LastName, string Email, string PhoneNumber,
            string JobTitle);

        ObservableCollection<ActionPartySetting> GetAllActionParties();

        List<string> GetActionPartiesFullNames();

        List<string> GetActionPartiesEmails();
    }
}
