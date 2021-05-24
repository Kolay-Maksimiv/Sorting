using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Model.Step;
using WebApi.ViewModel;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SortingController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// RandomArray
        /// </summary>
        public int[] RandomArray = RandomNumber();

        /// <summary>
        /// GetSorting
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetSorting()
        {
            var sortingViewModel = new SortingViewModel()
            {
                dataSoring = GetDataSoring(),
                combSortArray = GetHeapSort(RandomArray),
                quickSortingArray = GetQuickSorting(RandomArray)
            };

            return Ok(sortingViewModel);
        }

        /// <summary>
        /// GetDataSoring
        /// </summary>
        /// <returns></returns>
        private LineChartResponce<LineChartViewMode> GetDataSoring()
        {

            var dataSoring = new LineChartResponce<LineChartViewMode>
            {
                Data = new List<LineChartViewMode>() {
                    new LineChartViewMode()
                    {
                        Name = "CombSort",
                        Series = _context.combSortSteps.Select(x => new NameValueViewMode()
                        {
                            Name = x.C_StepID,
                            Value = x.C_Step
                        }).ToList()
                    },
                    new LineChartViewMode()
                    {
                        Name = "QuickSorting",
                        Series = _context.quickSortingSteps.Select(x => new NameValueViewMode()
                        {
                            Name = x.Q_StepID,
                            Value = x.Q_Step
                        }).ToList()
                    }

                }


            };

            return dataSoring;
        }
        /// <summary>
        /// RandomNumber
        /// </summary>
        /// <returns></returns>
        private static int[] RandomNumber()
        {
            int[] numRand = new int[10];
            Random rand = new Random();
            for (int ctr = 0; ctr < 10; ctr++)
                numRand[ctr] = rand.Next(0, 100);
            return numRand;
        }
        /// <summary>
        /// CombSort
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private IActionResult GetHeapSort(int[] array)
        {

            int n = array.Length;
            int step = 0;
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(array, n, i);

            for (int i = n - 1; i > 0; i--)
            {

                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
 
                heapify(array, i, 0);
            }


            void heapify(int[] arr, int n, int i)
            {
                int largest = i;
                int l = 2 * i + 1;
                int r = 2 * i + 2;

                if (l < n && arr[l] > arr[largest])
                    largest = l;


                if (r < n && arr[r] > arr[largest])
                    largest = r;
                step++;

                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;

                    heapify(arr, n, largest);
                }
            }



            var combSortViewModel = new CombSortViewModel()
            {
                arrayCombSort = array,
                combSortStep = step

            };
            var combSortStep = new CombSortStep();
            combSortStep.C_Step = step;
            _context.combSortSteps.Add(combSortStep);
            _context.SaveChanges();
            return Ok(combSortViewModel);
        }

        /// <summary>
        /// QuickSorting
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private IActionResult GetQuickSorting(int[] array)
        {


            int[] QuickSort(int[] array, int minIndex, int maxIndex)
            {
                if (minIndex >= maxIndex)
                {
                    return array;
                }

                var pivotIndex = Partition(array, minIndex, maxIndex);
                QuickSort(array, minIndex, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, maxIndex);

                return array;
            }

            static void Swap(ref int x, ref int y)
            {
                var t = x;
                x = y;
                y = t;
            }

            /// <summary>
            ///метод повертає індекс опорного елементу
            /// </summary>
            int step = 0;
            int Partition(int[] array, int minIndex, int maxIndex)
            {

                var pivot = minIndex - 1;
                for (var i = minIndex; i < maxIndex; i++)
                {
                    if (array[i] < array[maxIndex])
                    {
                        pivot++;
                        Swap(ref array[pivot], ref array[i]);
                        step++;
                    }

                }

                pivot++;

                Swap(ref array[pivot], ref array[maxIndex]);

                return pivot;
            }



            var quickSortingViewModel = new QuickSortingViewModel()
            {
                arrayQuickSorting = QuickSort(array, 0, array.Length - 1),
                quickSortingStep = step
            };


            var quickSortingStep = new QuickSortingStep();
            quickSortingStep.Q_Step = step;
            _context.quickSortingSteps.Add(quickSortingStep);
            _context.SaveChanges();
            return Ok(quickSortingViewModel);
        }


    }
}
