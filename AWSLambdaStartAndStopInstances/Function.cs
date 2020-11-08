using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaStartAndStopInstances
{
    public class Function
    {
        private AmazonEC2Client client;
        // Get Instance ids from Lambda environment variables.
        readonly List<string> instances = Environment.GetEnvironmentVariable("INSTANCES").Split(",").ToList();

        public Function()
        {
            // Create EC2 client designated region where you can start/stop instances.
            client = new AmazonEC2Client(Amazon.RegionEndpoint.APNortheast1);
        }

        public void FunctionHandler(string input, ILambdaContext context)
        {
            switch (input)
            {
                case "START":
                    StartInstances();
                    break;

                case "STOP":
                    StopInstances();
                    break;

                default:
                    throw new Exception("INPUT ERROR. TYPE 'START' OR 'STOP'.");
            }
        }

        private void StartInstances()
        {
            var request = new StartInstancesRequest(instances);
            var response = client.StartInstances(request);
            response.StartingInstances.ForEach(x => Console.WriteLine($"STARTING INSTANCE ID:{x.InstanceId}"));
        }

        private void StopInstances()
        {
            var request = new StopInstancesRequest(instances);
            var response = client.StopInstances(request);
            response.StoppingInstances.ForEach(x => Console.WriteLine($"STOPPING INSTANCE ID:{x.InstanceId}"));
        }
    }
}
