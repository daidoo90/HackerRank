using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank;

internal static class Solution
{
    internal static double Calculate(
        List<int> a_indexes,
        List<double> a_values,
        List<int> b_indexes,
        List<double> b_values)
    {
        double result = default;
        var count = a_indexes.Count;

        var aPairsDict = new Dictionary<int, double>();
        var aIndexesFound = new Dictionary<int, int>();

        var bPairsDict = new Dictionary<int, double>();
        var bIndexesFound = new Dictionary<int, int>();

        for (int i = 0; i < count; i++)
        {
            var aIndex = a_indexes[i];
            var aValue = a_values[i];

            if (aPairsDict.TryGetValue(aIndex, out var aPairValue))
            {
                aPairsDict[aIndex] = aPairValue + aValue;

                if(aIndexesFound.ContainsKey(aIndex))
                {
                    aIndexesFound[aIndex] = aIndexesFound[aIndex] + 1;
                }
                else
                {
                    aIndexesFound[aIndex] = 2;
                }
            }
            else
            {
                aPairsDict.Add(aIndex, aValue);
            }

            var bIndex = b_indexes[i];
            var bValue = b_values[i];

            if (bPairsDict.TryGetValue(bIndex, out var bPairValue))
            {
                bPairsDict[bIndex] = bPairValue + bValue;

                if (bIndexesFound.ContainsKey(bIndex))
                {
                    bIndexesFound[bIndex] = bIndexesFound[bIndex] + 1;
                }
                else
                {
                    bIndexesFound[bIndex] = 2;
                }
            }
            else
            {
                bPairsDict.Add(bIndex, bValue);
            }
        }

        foreach(var bPair in bPairsDict)
        {
            if(aPairsDict.TryGetValue(bPair.Key, out var aTotalValue))
            {
                var tempAValue = aTotalValue;

                if(aIndexesFound.TryGetValue(bPair.Key, out var totalFound))
                {
                    tempAValue = tempAValue / totalFound;
                }

                var tempBValue = bPair.Value;

                if (bIndexesFound.TryGetValue(bPair.Key, out var bTotalFound))
                {
                    tempBValue = tempBValue / bTotalFound;
                }

                result = result + (tempAValue * tempBValue);
            }
        }

        return result;
    }
}
