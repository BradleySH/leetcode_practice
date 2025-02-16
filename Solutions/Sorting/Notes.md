# Sorting


## QuickSort

Quick Sort is another divide and conquer algo used for sorting, similar to Merge Sort.

### Implementation

The idea behind quicksort is to pick an index, which is called the `pivot`. We then partition the array such that every value to the left is less than or equal to the `pivot` and every value to the right is greateer than the pivot.

#### Picking the pivot

There are several ways to pick the pivot value. Some of the common ways are: 

- Pick the first index
- Pick the last index
- Pick the median (pick the first, last and the middle value and their median and perform the split at the median)
- Pick a random index

Ideally we can pick a pivot that would divide the array into two roughly equal halves. This would result in the most efficient sorting scenario.

#### Recusive Partitioning

1. Once we pick a pivot we will partition the array such that all elements less than or equal to the pivot are on the left and the rest are on the right.
2. We will then recursively run quicksort on the left and right halves until we hit the base case which is an array size of `1`.

Unlike MergeSort, there is no need to merge the two halves because the partitioning step itseld is enough to sort the array.

![QuickSort](../../assets/pics/sharpen=1%20(1).avif)

### Time Complexity

Similar to MergeSort

The partition steps takes O(n) time and we do this for every level of the recursion tree. The number of levels in the recursion tree is O(logn) but only in the best case.

If the pivot is always in the middle of the array, then we can say that the number of levels in the recursion tree is O(logn).

If the pivot is always the smallest or largest element, then the number of levels in the recursion tree is O(n^2).

### Stability

QuickSort is not a stable sort.

## Bucket Sort

Bucket Sort is a sorting algorithm that works by distributing the elements of an array into a number of buckets. Each bucket is then sorted individually, either using a different sorting algorithm or by recursively applying the bucket sort algorithm.

### Implementation

1. Create a number of buckets equal to the range of the array.
2. Distribute the elements of the array into the buckets.
3. Sort each bucket individually.
4. Concatenate the buckets together.

![BucketSort](../../assets/pics/BucketSort.png)

### Time Complexity

O(n + k) where n is the number of elements in the array and k is the number of buckets.

### Stability

Bucket Sort is not a stable sort.