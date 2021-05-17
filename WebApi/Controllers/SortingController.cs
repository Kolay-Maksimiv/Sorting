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
                combSortArray = GetCombSort(RandomArray),
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
        //private IActionResult GetQuickSorting()
        //{
        //    Stopwatch clock = new Stopwatch();
        //    clock.Start();
        //    int[] QuickSortingArray = QuickSorting(RandomNumber());
        //    clock.Stop();
        //    double execution_time = (double)(clock.Elapsed.Ticks * 0.0001);

        //    var quickSortingViewModel = new QuickSortingViewModel
        //    {
        //        arrayQuickSorting = QuickSortingArray,
        //        executionTime = execution_time

        //    };

        //    var dataQuickSorting = new DataQuickSorting();
        //    dataQuickSorting.quickSortingTime = execution_time;
        //    _context.dataQuickSortings.Add(dataQuickSorting);
        //    _context.SaveChanges();

        //    return Ok(quickSortingViewModel);
        //}
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
        private IActionResult GetCombSort(int[] array)
        {
            var arrayLength = array.Length;
            var currentStep = arrayLength - 1;
            int step = 0;
            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                        step++;
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
