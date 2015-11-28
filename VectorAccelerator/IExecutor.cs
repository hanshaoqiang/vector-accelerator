﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorAccelerator.Distributions;

namespace VectorAccelerator
{    
    public enum RelativeOperator { LessThan, LessThanEquals, Equals, NotEquals, GreaterThanEquals, GreaterThan }
  
    public interface IExecutor
    {
        /// <summary>
        /// Assign operand2 to operand1
        /// </summary>
        void Assign<T>(NArray<T> operand1, NArray<T> operand2);

        /// <summary>
        /// Assign operand2 (result of call) to operand1, but only at points given by condition.
        /// We pass functions because in principle we may want to execute operand2 using a mask generated by condition.
        /// </summary>
        void Assign<T>(NArray<T> operand1, Func<NArray<T>> operand2, Func<NArrayBool> condition);

        #region Creation

        NArrayInt ConstantLike<T>(int constantValue, NArray<T> array);

        #endregion

        #region Binary

        void Add(NArray operand1, NArray operand2);

        NArray<T> ElementWiseAdd<T>(NArray<T> operand1, NArray<T> operand2);

        NArray<T> ElementWiseSubtract<T>(NArray<T> operand1, NArray<T> operand2);

        NArray<T> ElementWiseMultiply<T>(NArray<T> operand1, NArray<T> operand2);

        NArray<T> ElementWiseDivide<T>(NArray<T> operand1, NArray<T> operand2);

        NArrayBool LogicalOperation(NArrayBool operand1, NArrayBool operand2, LogicalBinaryElementWiseOperation op);

        NArrayBool RelativeOperation<T>(NArray<T> operand1, NArray<T> operand2, RelativeOperator op);

        void MatrixMultiply(NArray operand1, NArray operand2, NArray result);

        #endregion

        #region Unary

        NArray<T> UnaryElementWiseOperation<T>(NArray<T> operand, UnaryElementWiseOperation operation);

        NArray<int> RightShift(NArray<int> operand, int shift);

        NArray<int> LeftShift(NArray<int> operand, int shift);

        NArray<T> ElementWiseNegate<T>(NArray<T> operand);

        IDisposable CreateRandomNumberStream(StorageLocation location, RandomNumberGeneratorType type, int seed);

        void FillRandom(ContinuousDistribution distribution, NArray operand);

        NArray<T> Index<T>(NArray<T> operand, NArrayInt indices);

        void CholeskyDecomposition(NArray operand);

        void EigenvalueDecomposition(NArray operand, NArray eigenvectors, NArray eignenvalues);

        #endregion
    }
}
