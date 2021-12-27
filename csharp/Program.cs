using System.Diagnostics;
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input_data = new List<int>(){3,4,3,1,2};
            var input_data = new List<int>(){3,1,5,4,4,4,5,3,4,4,1,4,2,3,1,3,3,2,3,2,5,1,1,4,4,3,2,4,2,4,1,5,3,3,2,2,2,5,5,1,3,4,5,1,5,5,1,1,1,4,3,2,3,3,3,4,4,4,5,5,1,3,3,5,4,5,5,5,1,1,2,4,3,4,5,4,5,2,2,3,5,2,1,2,4,3,5,1,3,1,4,4,1,3,2,3,2,4,5,2,4,1,4,3,1,3,1,5,1,3,5,4,3,1,5,3,3,5,4,2,3,4,1,2,1,1,4,4,4,3,1,1,1,1,1,4,2,5,1,1,2,1,5,3,4,1,5,4,1,3,3,1,4,4,5,3,1,1,3,3,3,1,1,5,4,2,5,1,1,5,5,1,4,2,2,5,3,1,1,3,3,5,3,3,2,4,3,2,5,2,5,4,5,4,3,2,4,3,5,1,2,2,4,3,1,5,5,1,3,1,3,2,2,4,5,4,2,3,2,3,4,1,3,4,2,5,4,4,2,2,1,4,1,5,1,5,4,3,3,3,3,3,5,2,1,5,5,3,5,2,1,1,4,2,2,5,1,4,3,3,4,4,2,3,2,1,3,1,5,2,1,5,1,3,1,4,2,4,5,1,4,5,5,3,5,1,5,4,1,3,4,1,1,4,5,5,2,1,3,3};

            var input_map = new Dictionary<int, decimal>();
            input_map[-1]=0;
            input_map[0]=0;
            input_map[1]=0;
            input_map[2]=0;
            input_map[3]=0;
            input_map[4]=0;
            input_map[5]=0;
            input_map[6]=0;
            input_map[7]=0;
            input_map[8]=0;
            foreach(var i in input_data)
            {
                input_map[i]++;
            }
            var watch = new Stopwatch();
            watch.Start();
            
            IEnumerable<int> input = input_data;
            for(var day=1;day<=80;++day)
            {
                watch.Restart();
                input = input.Select(o=>--o);
                var newFishes = input.Where(o=>o<0).Select(o=>8);
                input=input.Select(o=> 
                {
                    return o<0 ? 6 : o;       
                }).ToList(); // ToList() needs to be done here to avoid delayed evaluation. It will hang otherwise.
                input = input.Concat(newFishes);
                watch.Stop();
                Console.WriteLine($"Day: {day}, Execution Time: {watch.ElapsedMilliseconds} ms");
            }
            watch.Stop();
            //input.ToList().ForEach(o=>Console.Write($"{o},"));
            Console.WriteLine();
            Console.WriteLine($"Nr of fishes: {input.Count()}");

            for(var day=1;day<=256;++day)
            {
                input_map.Keys.OrderBy(o=>o).ToList().ForEach(o=>input_map[o-1]=input_map[o]);
                input_map[8]=input_map[-1];
                input_map[6]+=input_map[-1];
                input_map[-1]=0;
            }
            Console.WriteLine($"Nr of fishes: {input_map.Values.Sum()}");
        }
    }
}