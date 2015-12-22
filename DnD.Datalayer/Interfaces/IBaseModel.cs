using System;

namespace DnD.Datalayer.Interfaces
{
    public interface IBaseModel
    {
        int Id { get; set; }

        DateTimeOffset DateCreated { get; set; }

        DateTimeOffset DateUpdated { get; }
    }
}