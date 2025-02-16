# Binary Search

Binary Search is a search algorithm that finds the position of a target value within a sorted array.

### Implementation

1. Compare the target value to the middle element of the array.
2. If the target value is equal to the middle element, then return the index of the middle element.
3. If the target value is less than the middle element, then search the left half of the array.

### Sudo Code

```
int binarySearch(arr, target) {
    int left = 0;
    int right = arr.length - 1;

    while left <= right {
        mid = (left + right) / 2;

        if target > arr[mid]
            left = mid +1
        else if target < arr[mid]
            right = mid - 1
        else 
            return mid
    }

    return -1
}
```

### Time Complexity

O(logn)

### Space Complexity

O(1)
