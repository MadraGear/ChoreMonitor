using System;
using System.Collections.Generic;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace ChoreMonitor.DockerTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("unix:/var/run/docker.sock");
            DockerClient client = new DockerClientConfiguration(uri)
                .CreateClient();


            IList<ImagesListResponse> images = client.Images
                .ListImagesAsync
                (
                    new ImagesListParameters()
                )
                .GetAwaiter()
                .GetResult();

            foreach(ImagesListResponse image in images)
            {
                Console.WriteLine($"{image.ID}");
            }


            IList<ContainerListResponse> containers = client.Containers
                .ListContainersAsync
                (
                    new ContainersListParameters(){
                        Limit = 10,
                    }
                )
                .GetAwaiter()
                .GetResult();

            foreach(ContainerListResponse container in containers)
            {
                Console.WriteLine($"{container.ID} - {container.Command} ");
                // client.Containers.StartContainerAsync(
                //     container.ID, new ContainerStartParameters{ })
                //     .GetAwaiter()
                //     .GetResult();
            }

            

            Console.WriteLine("Hello World!");
        }
    }
}
