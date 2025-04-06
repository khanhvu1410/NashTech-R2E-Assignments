using ToDoApiAssignment.Application.DTOs;
using ToDoApiAssignment.Application.Interfaces;
using ToDoApiAssignment.Application.Mappings;
using ToDoApiAssignment.Domain.Interfaces;

namespace ToDoApiAssignment.Application.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public ToDoItemDTO CreateItem(ToDoItemToCreateDTO itemDto)
        {
            var items = _toDoItemRepository.GetAllItems().ToList();
            
            var id = items.Count == 0 ? 1 : items.Max(i => i.Id) + 1;
            
            var createdItem = _toDoItemRepository.CreateItem(itemDto.ToItem(id));
            
            return createdItem.ToItemDTO();
        }

        public void DeleteItem(int id)
        {
            var item = _toDoItemRepository.GetItemById(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"No item with ID {id} found.");
            }

            _toDoItemRepository.DeleteItem(id);
        }

        public IEnumerable<ToDoItemDTO> GetAllItems()
        {
            var items = _toDoItemRepository.GetAllItems().ToList();

            if (items.Count == 0)
            {
                throw new KeyNotFoundException("No item found.");
            }

            return items.Select(i => i.ToItemDTO());
        }

        public ToDoItemDTO GetItemById(int id)
        {
            var item = _toDoItemRepository.GetItemById(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"No item with ID {id} found.");
            }

            return item.ToItemDTO();
        }

        public ToDoItemDTO UpdateItem(ToDoItemDTO itemDto)
        {
            var existingItem = _toDoItemRepository.GetItemById(itemDto.Id);

            if (existingItem == null) 
            {
                throw new KeyNotFoundException($"No item with ID {itemDto.Id} found.");
            }

            if (itemDto.Title != null)
            {
                existingItem.Title = itemDto.Title;
            }

            if (itemDto.IsCompleted != null)
            {
                existingItem.IsCompleted = (bool)itemDto.IsCompleted;
            }

            existingItem.UpdatedAt = DateTime.Now;

            var item = _toDoItemRepository.UpdateItem(existingItem);

            return item.ToItemDTO();
        }

        public IEnumerable<ToDoItemDTO> CreateMultipleItems(IEnumerable<ToDoItemToCreateDTO> items)
        {
            var createdItems = new List<ToDoItemDTO>();

            foreach (var item in items)
            {
                var createdItem = CreateItem(item);
                createdItems.Add(createdItem);
            }

            return createdItems; 
        }

        public void DeleteMultipleItems(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                DeleteItem(id);
            }
        }
    }
}
