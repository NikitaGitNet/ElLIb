using ElLIb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElLIb.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IEnumerable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
