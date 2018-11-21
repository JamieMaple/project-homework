from requests import get
from time import time
import csv


def handleSourceFile(filename):
    f = open(filename)
    ids = []
    for line in f.readlines():
        if (line.startswith("#")):
            continue
        ids.append(line.strip())
    f.close()
    return ids


link = 'https://www.ele.me/restapi/shopping/v2/menu'


def sendRequest(restaurant_id):
    headers = {
        'x-shard': 'shopid=%s;loc=114.290236,30.582352' % restaurant_id,
    }
    params = {
        'restaurant_id': restaurant_id,
        'terminal': 'web',
    }
    return get(link, params=params, headers=headers).json()


class Food:
    img_prefix = 'http://fuss10.elemecdn.com'

    def fixImg(img_url):
        if (len(img_url) <= 0):
            return ""
        return '%s/%s/%s/%s.jpeg' % (
            Food.img_prefix, img_url[0], img_url[1:3], img_url[3:])

    def __init__(self, food_id, name, unit_price, img_url, category):
        self.id = food_id
        self.name = name
        self.unit_price = unit_price
        self.category = category
        self.img_url = Food.fixImg(img_url)
        self.create_at = int(time())


class Category:
    index = 0

    def getId():
        Category.index += 1
        return Category.index

    def __init__(self, category_id, name):
        self.id = category_id
        self.name = name
        self.create_at = int(time())


def getFoodsAndCategories(ids):
    data = []
    data_set = []
    categories_set = []
    categories = []
    for index, restaurant_id in enumerate(ids):
        category_list = sendRequest(restaurant_id)
        for category in category_list:
            category_name = category["name"]
            if category_name in ["一起嗨畅享套餐", "品牌专场", "我要加料", "小火锅菜品份量详解", "感恩节热饮分享装", "海底捞外送特色饮品", "捞粉的温馨提示", "网红抖音吃法组合", "天猫兑换券", "天天半价工作餐", "下架商品", "热销", "优惠", "🔥人气推荐🔥", "今日新品", "店内招牌", "店长推荐", "当季热销", "今日特价", "凑单专区", "扫码惊喜", "须知店长"]:
                continue
            for food in category["foods"]:
                food_id = food["specfoods"][0]["food_id"]
                if (food_id in data_set):
                    continue
                else:
                    data_set.append(food_id)
                category_id = 0
                img_url = ""
                if category_name in categories_set:
                    category_id = categories_set.index(category_name)
                else:
                    category_id = Category.getId()
                    categories.append(Category(category_id, category_name))
                    categories_set.append(category_name)
                if len(food["photos"]) >= 1:
                    img_url = food["photos"][0]
                data.append(
                    Food(
                        food_id,
                        food["name"],
                        food["specfoods"][0]["price"],
                        img_url,
                        category_id
                    ))

    return data, categories


def saveToCSV(filename, dataList):
    with open(filename, 'w', newline='', encoding='utf8') as f:
        writer = csv.DictWriter(f, dataList[0].__dict__.keys())
        writer.writeheader()
        for row in dataList:
            writer.writerow(row.__dict__)
    f.close()


class Room:
    index = 0

    def __init__(self, room_name, floor):
        Room.index += 1
        self.id = Room.index
        self.name = room_name
        self.floor = floor
        create_at = int(time())
        self.create_at = create_at
        self.last_update_at = create_at


def roomsGenerator(floors, count):
    rooms = []
    for out in range(floors):
        floor = out + 1
        for inner in range(count):
            c = inner + 1
            rooms.append(Room("{:d}{:02d}".format(floor, c), floor))
    return rooms


if __name__ == "__main__":
    # ids = handleSourceFile("source.txt")
    # foods, categories = getFoodsAndCategories(ids)
    # saveToCSV('foods.csv', foods)
    # saveToCSV('categories.csv', categories)
    saveToCSV('rooms.csv', roomsGenerator(20, 15))
