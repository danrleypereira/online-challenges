

class MyHashSet:
    # Runtime: 1647 ms, faster than 16.92%
    # Memory Usage: 41.3 MB, less than 5.20%
    def __init__(self):
        self.list = [None for _ in range(1000000+1)]

    def add(self, key: int) -> None:
        if not self.contains(key):
            self.list[key] = key

    def remove(self, key: int) -> None:
        if self.contains(key):
            self.list[key] = None

    def contains(self, key: int) -> bool:
        if self.list[key] is not None:
            return True
        return False

class MyHashSetWithBuckets:

    def __init__(self):
        self.hash = [[] for _ in range(1000)]
        
    def add(self, key: int) -> None:
        if not self.contains(key):
            val = key%1000
            self.hash[val].append(key)

    def remove(self, key: int) -> None:
        if self.contains(key):
            val = key%1000
            self.hash[val].remove(key)

    def contains(self, key: int) -> bool:
        val = key%1000
        return key in self.hash[val]

# Your MyHashSet object will be instantiated and called as such:
# obj = MyHashSet()
# obj.add(key)
# obj.remove(key)
# param_3 = obj.contains(key)
