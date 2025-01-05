using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using VetTail.Domain.Enums;

namespace VetTail.Infrastructure.Common.Converters
{
    public class MovementTypeConvertor : ValueConverter<MovementType, string>
    {
        public MovementTypeConvertor() :
            base(
                movementType => movementType.ToString(),
                value => (MovementType)Enum.Parse(typeof(MovementType), value)
            ) { }
    }
}
