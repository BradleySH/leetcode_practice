namespace NeetcodeSolutions.Solutions.LinkedLists
{
    public class Cafeteria
    {
        public static int CountStudentsUnableToEat(int[] students, int[] sandwiches)
        {
            // Initialize the queue with all student preferences
            Queue<int> queue = new(students);

            int sandwichIndex = 0; // Points to the current sandwich 
            int unsuccessfulAttempts = 0; // Tracks the number of students who couldn't eat

            // Continue while there are students and sandwiches
            while (queue.Count > 0 && unsuccessfulAttempts < queue.Count)
            {
                int student = queue.Dequeue();

                if (student == sandwiches[sandwichIndex])
                {
                    sandwichIndex++;
                    unsuccessfulAttempts = 0;
                }
                else
                {
                    queue.Enqueue(student);
                    unsuccessfulAttempts++;
                }
            }

            // Return the number of students who couldn't eat
            return queue.Count;
        }
    }
}