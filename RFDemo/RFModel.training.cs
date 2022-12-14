﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace RFDemo
{
    public partial class RFModel
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Text.FeaturizeText(@"ClaimID_tf", @"ClaimID")      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Provider_tf", @"Provider"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"AttendingPhysician_tf", @"AttendingPhysician"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"OperatingPhysician_tf", @"OperatingPhysician"))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"BeneID", @"BeneID"))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"InscClaimAmtReimbursed", @"InscClaimAmtReimbursed"))      
                                    .Append(mlContext.Recommendation().Trainers.MatrixFactorization(approximationRank:128,numberOfIterations:10,learningRate:0.01F,labelColumnName:@"Fraud_Reported",matrixColumnIndexColumnName:@"BeneID",matrixRowIndexColumnName:@"InscClaimAmtReimbursed"));

            return pipeline;
        }
    }
}
