﻿using Portal.Domain.Entities.Abstract;
using Portal.Domain.Interfaces;

namespace Portal.Domain.GenericSpecification
{
    internal class AndSpecification<T> : Specification<T> where T : BaseEntity
    {
        ISpecification<T> leftSpec;
        ISpecification<T> rightSpec;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            leftSpec = first;
            rightSpec = second;
        }

        public override bool IsSatisfiedBy(T item)
        {
            return leftSpec.IsSatisfiedBy(item) 
                && rightSpec.IsSatisfiedBy(item);
        }
    }
}