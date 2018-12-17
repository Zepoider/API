using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    class Driver<T>
    {
        Cell<T> first;
        Cell<T> last;
        Cell<T> current;
        public int count;
        public int lenth;

        //Constructor Default
        public Driver()
        {
            this.first = null;
            this.last = null;
            this.current = null;
            this.count = 0;
            this.lenth = 0;
        }

        //Constructor for create collecton whith any number empty cell
        public Driver(int numberOfCell)
        {
            for (int i = 0; i < numberOfCell; i++)
            {
                Add(new Cell<T>());
            }
        }

        //Remove cell
        public void Remove(Cell<T> cell)
        {
            lenth--;
            if (cell.data != null)
            {
                count--;
            }

            ShiftLeft(cell);

            cell.next = null;
            cell.previous = null;
        }

        //Convert collection to array
        public Cell<T>[] ToArray()
        {
            Cell<T>[] array = new Cell<T>[lenth];

            for (int i = 0; i < lenth; i++)
            {
                array[i] = ForCycle(i);
            }

            return array;
        }

        //Remove cell by index
        public void RemoveByIndex(int index)
        {
            Remove(GetByIndex(index));
        }

        //Return true if collectioon have not empty cell
        public bool Any()
        {
            if (count > 0)
            {
                return true;
            }

            return false;
        }

        //Take cell by index
        public Cell<T> GetByIndex(int index)
        {
            Cell<T> tempCell = null;

            for (int i = 0; i < lenth; i++)
            {
                tempCell = ForCycle(i);

                if (tempCell.index == index)
                {
                    break;
                }
            }

            return tempCell;
        }

        //Use this functin for cycle, consistently returns the cell
        Cell<T> ForCycle(int number)
        {
            if (number == 0)
            {
                current = null;
            }

            if (current == null)
            {
                current = first;
                return first;
            }
            else
            {
                current = current.next;

                if (current != last)
                {
                    return current;
                }
            }
            return last;
        }

        //Add cell to the end of collection
        public void Add(Cell<T> cell)
        {
            if (first == null)
            {
                first = cell;
                first.index = 0;
            }
            else
            {
                last.next = cell;
                cell.index = last.index + 1;
                cell.previous = last;
            }

            last = cell;
            if (cell.data != null)
            {
                count++;
            }
            lenth++;
        }

        //Insert cell t collectoin by index
        public void InsertInIndex(int index, Cell<T> cell)
        {
            if (cell.data != null)
            {
                count++;
            }
            lenth++;

            if (index != first.index)
            {
                Cell<T> tempCellLeft = GetByIndex(index - 1);
                Cell<T> tempCellRight = GetByIndex(index);
                cell.previous = tempCellLeft;
                tempCellLeft.next = cell;
                cell.next = tempCellRight;
                tempCellRight.previous = cell;
            }
            else
            {
                cell.next = first;
                first.previous = cell;
                first = cell;
            }

            cell.index = cell.next.index;

            while (cell.next != null)
            {
                cell.next.index++;
                cell = cell.next;
            }
        }

        //Sort collection by value
        public void Sort()
        {
                SortAlgo();
        }

        //Use for shift left cell in collection
        void ShiftLeft(Cell<T> cell)
        {
            if (cell == last)
            {
                last = last.previous;
                last.next = null;
            }
            else if (cell == first)
            {
                first = cell.next;
                first.previous = null;
            }
            else
            {
                cell.next.previous = cell.previous;
                cell.previous.next = cell.next;
            }

            while (cell.next != null)
            {
                cell.next.index--;
                cell = cell.next;
            }
        }

        //Very strange sorting, but it works :)
        void SortAlgo()
        {
            Cell<T> currentCell = null;
            Cell<T> nextCell = null;

            int lenghtDelta;

            for (int k = 0; k < lenth; k++)
            {
                currentCell = GetByIndex(k);

                for (int j = 0; j < lenth; j++)
                {
                    nextCell = GetByIndex(j);

                    if (currentCell.data.ToString().Length >= nextCell.data.ToString().Length)
                    {
                        lenghtDelta = nextCell.data.ToString().Length;
                    }
                    else
                    {
                        lenghtDelta = currentCell.data.ToString().Length;
                    }

                    for (int d = 0; d < lenghtDelta; d++)
                    {
                        if (currentCell.data.ToString().ToLower()[d] > nextCell.data.ToString().ToLower()[d])
                        {
                            if (currentCell.index < nextCell.index)
                            {
                                Cell<T> tempCell = new Cell<T>();
                                tempCell.data = nextCell.data;

                                InsertInIndex(currentCell.index, tempCell);

                                Remove(nextCell);

                                break;
                            }
                        }
                        else if (currentCell.data.ToString()[d] < nextCell.data.ToString()[d])
                        {
                            if (currentCell.index > nextCell.index)
                            {
                                Cell<T> tempCell = new Cell<T>();
                                tempCell.data = currentCell.data;

                                InsertInIndex(nextCell.index, tempCell);

                                Remove(currentCell);
                                currentCell = nextCell.previous;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
