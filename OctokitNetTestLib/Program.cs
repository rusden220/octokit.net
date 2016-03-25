using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace OctokitNetTestLib
{
	public class OctakitTest
	{
		public async Task Run()
		{
			var gh = new BlobsClient(new ApiConnection(new Connection(new ProductHeaderValue("OctokitNetTestLib"))));			
			//Get blob from repo by name
			Blob blobFromRepo = await gh.Get("rusden220", "BlobTest", "dd37f279ab79447f14c7b8deeed50959ebf9d979");
			//Get blob from repositories by id
			Blob blobFrompRepoId = await gh.Get("54711605", "dd37f279ab79447f14c7b8deeed50959ebf9d979");
			//compare
			if (blobFromRepo.Sha == blobFrompRepoId.Sha && blobFromRepo.Content == blobFrompRepoId.Content)
			{
				Console.WriteLine("a blob from repo by id and blob from repo by name are equals");
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Test for GSoC 2016 in issues 112 from github");
			Console.WriteLine("https://github.com/github/mentorships/issues/112");
			new OctakitTest().Run().Wait();
			Console.WriteLine("press enter to exit");
			Console.ReadLine();
		}

	}
}
