using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
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
        /// GetSorting
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetSorting()
        {
            var dataCombSorts = _context.dataCombSorts;
            var dataQuickSortings = _context.dataQuickSortings;

            var sortingViewModel = new SortingViewModel()
            {   dataSoring = GetDataSoring(),
                //dataQuickSortings = dataQuickSortings,
                //dataCombSorts = dataCombSorts,
                combSortArray = GetCombSort(),
                quickSortingArray = GetQuickSorting()
            };

            return Ok(sortingViewModel);
        }


        private async Task<LineChartResponce<LineChartViewMode>> GetDataSoring()
        {

            var dataSoring = new LineChartResponce<LineChartViewMode>
            {
                Data = new List<LineChartViewMode>() {
                    new LineChartViewMode()
                    {
                        Name = "CombSort",
                        Series = _context.dataCombSorts.Select(x => new NameValueViewMode()
                        {
                            Name = x.combSortID,
                            Value = x.combSortTime
                        }).ToList()
                    },
                    new LineChartViewMode()
                    {
                        Name = "GetCombSort",
                        Series = _context.dataQuickSortings.Select(x => new NameValueViewMode()
                        {
                            Name = x.quickSortingID,
                            Value = x.quickSortingTime
                        }).ToList()
                    }
                }

            };

            return dataSoring;
        }
        /// <summary>
        /// GetCombSort
        /// </summary>
        /// <returns></returns>
        private IActionResult GetCombSort()
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            int[] CombSortArray = CombSort(RandomNumber());
            clock.Stop();
            double execution_time = (double)(clock.Elapsed.Ticks * 0.0001);

            var combSortViewModel = new CombSortViewModel
            {
                arrayCombSort = CombSortArray,
                executionTime = execution_time

            };

            var dataCombSort = new DataCombSort();
            dataCombSort.combSortTime = execution_time;
            _context.dataCombSorts.Add(dataCombSort);
            _context.SaveChanges();

            return Ok(combSortViewModel);
        }
        /// <summary>
        /// GetQuickSorting
        /// </summary>
        /// <returns></returns>
        private IActionResult GetQuickSorting()
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            int[] QuickSortingArray = QuickSorting(RandomNumber());
            clock.Stop();
            double execution_time = (double)(clock.Elapsed.Ticks * 0.0001);

            var quickSortingViewModel = new QuickSortingViewModel
            {
                arrayQuickSorting = QuickSortingArray,
                executionTime = execution_time

            };

            var dataQuickSorting = new DataQuickSorting();
            dataQuickSorting.quickSortingTime = execution_time;
            _context.dataQuickSortings.Add(dataQuickSorting);
            _context.SaveChanges();

            return Ok(quickSortingViewModel);
        }
        /// <summary>
        /// RandomNumber
        /// </summary>
        /// <returns></returns>
        private static int[] RandomNumber()
        {
            int[] numRand = new int[20];
            Random rand = new Random();
            for (int ctr = 0; ctr < 20; ctr++)
                numRand[ctr] = rand.Next(0, 100);
            return numRand;
        }
        /// <summary>
        /// CombSort
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] CombSort(int[] array)
        {
            var arrayLength = array.Length;
            var currentStep = arrayLength - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }

                currentStep = GetNextStep(currentStep);
            }

            /// <summary>
            /// сортування бульбашкою
            /// </summary>
            for (var i = 1; i < arrayLength; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < arrayLength - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
            static void Swap(ref int value1, ref int value2)
            {
                var temp = value1;
                value1 = value2;
                value2 = temp;
            }

            static int GetNextStep(int s)
            {
                s = s * 1000 / 1247;
                return s > 1 ? s : 1;
            }

            return array;
        }

        /// <summary>
        /// QuickSorting
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] QuickSorting(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);

            static int[] QuickSort(int[] array, int minIndex, int maxIndex)
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
            static int Partition(int[] array, int minIndex, int maxIndex)
            {
                var pivot = minIndex - 1;
                for (var i = minIndex; i < maxIndex; i++)
                {
                    if (array[i] < array[maxIndex])
                    {
                        pivot++;
                        Swap(ref array[pivot], ref array[i]);
                    }
                }

                pivot++;
                Swap(ref array[pivot], ref array[maxIndex]);
                return pivot;
            }
        }


    }
}
