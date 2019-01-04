# ************************************************************
# Sequel Pro SQL dump
# Version 5426
#
# https://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 8.0.11)
# Database: cs_hotel
# Generation Time: 2019-01-04 09:34:19 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
SET NAMES utf8mb4;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table category
# ------------------------------------------------------------

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `create_at` int(11) NOT NULL,
  `delete_at` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;

INSERT INTO `category` (`id`, `name`, `create_at`, `delete_at`)
VALUES
	(1,'莎士雷可',1542809125,0),
	(2,'俄式面包烘培',1542809125,0),
	(3,'汤品',1542809125,0),
	(4,'沙拉类',1542809125,0),
	(5,'开胃头盘类',1542809125,0),
	(6,'主菜',1542809125,0),
	(7,'佐餐蔬菜',1542809125,0),
	(8,'主食',1542809125,0),
	(9,'俄式大薄饼披萨',1542809125,0),
	(10,'餐后甜品',1542809125,0),
	(11,'轻食',1542809125,0),
	(12,'乌冬面',1542809126,0),
	(13,'日式丼',1542809126,0),
	(14,'经典咖喱',1542809126,0),
	(15,'超值套餐',1542809126,0),
	(16,'天妇罗',1542809126,0),
	(17,'精美小食',1542809126,0),
	(18,'饭团寿司',1542809126,0),
	(19,'饮料',1542809126,0),
	(20,'水果沙拉',1542809126,0),
	(21,'单果鲜切',1542809126,0),
	(22,'果切拼盘',1542809126,0),
	(23,'送礼果篮，礼盒',1542809126,0),
	(24,'苹果香蕉梨',1542809126,0),
	(25,'平安果系列',1542809126,0),
	(26,'商务套餐系列',1542809126,0),
	(27,'葡提桨果',1542809126,0),
	(28,'芒橙柑桔柚',1542809126,0),
	(29,'樱桃 荔枝 葡提拼盘',1542809126,0),
	(30,'鲜切六拼',1542809126,0),
	(31,'鲜切四拼',1542809126,0),
	(32,'鲜果单切',1542809126,0),
	(33,'鲜切五拼',1542809126,0),
	(34,'小零食',1542809126,0),
	(35,'单品汉堡',1542809126,0),
	(36,'套餐汉堡',1542809126,0),
	(37,'甜点小吃',1542809126,0),
	(38,'饮品系列',1542809126,0),
	(39,'超人气组合餐',1542809126,0),
	(40,'超人气组合套餐',1542809126,0),
	(41,'甜品小吃',1542809126,0),
	(42,'找醇茶',1542809128,0),
	(43,'找好茶',1542809128,0),
	(44,'找奶茶',1542809128,0),
	(45,'找口感',1542809128,0),
	(46,'找鲜奶',1542809128,0),
	(47,'找新鲜',1542809128,0),
	(48,'锅底类',1542809128,0),
	(49,'锅具类',1542809128,0),
	(50,'网红必选小料',1542809128,0),
	(51,'小料类',1542809128,0),
	(52,'牛羊肉类',1542809128,0),
	(53,'特色菜类',1542809128,0),
	(54,'经典火锅菜类',1542809128,0),
	(55,'丸滑类',1542809128,0),
	(56,'海鲜/河鲜类',1542809128,0),
	(57,'根茎与菌类',1542809128,0),
	(58,'豆制品类',1542809128,0),
	(59,'叶菜类',1542809128,0),
	(60,'小吃类',1542809128,0),
	(61,'饮品类',1542809128,0);

/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table food
# ------------------------------------------------------------

DROP TABLE IF EXISTS `food`;

CREATE TABLE `food` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '未知菜品',
  `unit_price` float NOT NULL DEFAULT '0',
  `category` int(11) DEFAULT NULL,
  `img_url` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `create_at` int(11) NOT NULL,
  `delete_at` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

LOCK TABLES `food` WRITE;
/*!40000 ALTER TABLE `food` DISABLE KEYS */;

INSERT INTO `food` (`id`, `name`, `unit_price`, `category`, `img_url`, `create_at`, `delete_at`)
VALUES
	(38947688,'炫辣鸡腿堡套餐',32,36,'http://fuss10.elemecdn.com/2/9c/fccb7e464ba605b4eaf42b87858depng.png',1542884586,0),
	(38947692,'小皇堡套餐',29,36,'http://fuss10.elemecdn.com/0/cc/fd8f1da66ad2f9abbbd1120e18180png.png',1542884586,0),
	(38947694,'天椒小皇堡套餐',29,36,'http://fuss10.elemecdn.com/0/cc/fd8f1da66ad2f9abbbd1120e18180png.png',1542884586,0),
	(38947746,'香脆鳕鱼堡套餐',34,36,'http://fuss10.elemecdn.com/5/5e/6654c1924dbd1c186f6178ed83204png.png',1542884586,0),
	(82708030,'山东至尊烟台富士大盒装',88,23,'http://fuss10.elemecdn.com/5/71/bfb0ebe17bcd5b6646161ae74c124jpeg.jpeg',1542884586,0),
	(82708039,'祝福礼品水果盒(自由搭配)',98,23,'http://fuss10.elemecdn.com/d/bf/3cdc90dc905225cee446e258a10e4jpeg.jpeg',1542884586,0),
	(82708041,'精品水果篮(现配包新鲜，含多种进口水果)',188,23,'http://fuss10.elemecdn.com/e/ad/641df85d31736261e09905b031f80jpeg.jpeg',1542884586,0),
	(82708449,'新鲜香蕉切盒装单拼',24.8,24,'http://fuss10.elemecdn.com/b/d0/69307ce0f8dedb8c7e96bf27f8c72jpeg.jpeg',1542884586,0),
	(82708455,'雪梨单切果盘 400g起',6.79,33,'http://fuss10.elemecdn.com/2/a6/deabf49b09a66c816b891fee724e0jpeg.jpeg',1542884586,0),
	(86070775,'现切白心火龙果盒装 300g',24.8,32,'http://fuss10.elemecdn.com/c/7e/744e203797555534ecee2776c2d57jpeg.jpeg',1542884586,0),
	(86082169,'「鲜切」海南红心牛奶木瓜约300g',24.8,32,'http://fuss10.elemecdn.com/4/52/d896d6e2f63e7c901cdfb9fa95606jpeg.jpeg',1542884586,0),
	(124867597,'果木香风味火烤鸡腿堡套餐',35,37,'http://fuss10.elemecdn.com/5/ff/6000cb28d02896669211e95c9e15dpng.png',1542884586,0),
	(124867612,'炫辣鸡腿堡',19,35,'http://fuss10.elemecdn.com/0/d1/a82d102fb4445d4e723581a3b0f14png.png',1542884586,0),
	(124867620,'小皇堡',16,35,'http://fuss10.elemecdn.com/2/88/14632bd82b6b86c711bb2b523a841png.png',1542884586,0),
	(124867624,'天椒小皇堡',16,35,'http://fuss10.elemecdn.com/2/88/14632bd82b6b86c711bb2b523a841png.png',1542884586,0),
	(124867656,'香脆鳕鱼堡',19,36,'http://fuss10.elemecdn.com/f/79/a0f71b744cb11886ba788c601b293jpeg.jpeg',1542884586,0),
	(124867701,'洋葱圈',11,38,'http://fuss10.elemecdn.com/0/0f/f50d106d2cf8f38e62d5a5c61433epng.png',1542884586,0),
	(124867706,'王道川蜀鸡翅',12,37,'http://fuss10.elemecdn.com/f/fb/2216475f12e82db40d559e57c13fapng.png',1542884586,0),
	(124867715,'王道椒香鸡腿',12,37,'http://fuss10.elemecdn.com/e/ed/cf60fce3bca1fb41227128a076a04png.png',1542884586,0),
	(124867729,'百事杯装可乐（中杯)',10.5,38,'http://fuss10.elemecdn.com/b/4f/bbba03853806977fa9840d57075c2png.png',1542884586,0),
	(124867735,'百事杯装可乐（大杯)',12,38,'http://fuss10.elemecdn.com/b/4f/bbba03853806977fa9840d57075c2png.png',1542884586,0),
	(124867740,'百事杯装美年达（中杯）',10.5,38,'http://fuss10.elemecdn.com/7/c0/bcdcba6795f0c0bcdcac6091a56capng.png',1542884586,0),
	(124867747,'百事杯装美年达（大杯）',12,38,'http://fuss10.elemecdn.com/7/c0/bcdcba6795f0c0bcdcac6091a56capng.png',1542884586,0),
	(124867759,'百事杯装七喜（中杯)',10.5,39,'http://fuss10.elemecdn.com/7/aa/7fdbccfad7213d661f86bc0d1a40bpng.png',1542884586,0),
	(124867788,'百事杯装美年达（小杯）',8,38,'http://fuss10.elemecdn.com/7/c0/bcdcba6795f0c0bcdcac6091a56capng.png',1542884586,0),
	(131452901,'日式牛肉饭',25,12,'http://fuss10.elemecdn.com/c/7c/cc490b2245292270125648df98778jpeg.jpeg',1542884585,0),
	(131452902,'咖喱饭',23,14,'http://fuss10.elemecdn.com/1/ad/8d9d1a6cc7f4a5ef01e8ed3d29d2cjpeg.jpeg',1542884585,0),
	(131452904,'猪软骨番茄饭',30,13,'http://fuss10.elemecdn.com/6/97/2b03a55b3977e60eae713a9b11920jpeg.jpeg',1542884585,0),
	(131452905,'牛肉番茄饭',25,12,'http://fuss10.elemecdn.com/4/39/2cef843d882730d9ecfb88d613324jpeg.jpeg',1542884585,0),
	(131452906,'麻辣番茄饭',23,12,'http://fuss10.elemecdn.com/7/bf/496d9e1bc42a60299db086026b7adjpeg.jpeg',1542884585,0),
	(131452907,'清汤乌冬面',15,11,'http://fuss10.elemecdn.com/3/f9/956fcc80d259502d77c9133d7dfe6jpeg.jpeg',1542884585,0),
	(131452909,'牛肉乌冬面',25,11,'http://fuss10.elemecdn.com/6/a6/216d82550152ee2b853f37dc3b53cjpeg.jpeg',1542884585,0),
	(131452911,'高汤乌冬面',26,11,'http://fuss10.elemecdn.com/5/8e/2e33e192280582c9b57330a4ebc12jpeg.jpeg',1542884585,0),
	(131452915,'牛肉番茄乌冬面',28,11,'http://fuss10.elemecdn.com/b/7b/3349bc869d8e2085a35b7ec791652jpeg.jpeg',1542884585,0),
	(131452918,'猪软骨乌冬面',32,11,'http://fuss10.elemecdn.com/0/6d/d2462965b88ae2cb6f102b72d61f4jpeg.jpeg',1542884585,0),
	(131452920,'和风咖喱乌冬面',23,13,'http://fuss10.elemecdn.com/e/8f/42e043bc1a14fab8d06745fb93a20jpeg.jpeg',1542884585,0),
	(131452923,'酸汤肥牛乌冬面',24,11,'http://fuss10.elemecdn.com/c/a5/c2d84ce8ab90059812515d43f26e8jpeg.jpeg',1542884585,0),
	(131452926,'麻辣乌冬面',25,11,'http://fuss10.elemecdn.com/c/21/c8819e347f9aaafbc5b01861eb7fejpeg.jpeg',1542884585,0),
	(131452928,'鲜蔬乌冬面',23,11,'http://fuss10.elemecdn.com/e/0a/a060165f5314bbc137551844f54fajpeg.jpeg',1542884585,0),
	(131452931,'牛肉麻酱拌乌冬',27,11,'http://fuss10.elemecdn.com/1/be/0485108d19e92fb2c4cf1bac39e31jpeg.jpeg',1542884585,0),
	(131452935,'炸虾饼',10,16,'http://fuss10.elemecdn.com/7/0d/0db51bf6f4074deb3fe9f69a557e9jpeg.jpeg',1542884585,0),
	(131452942,'炸鸡肉串',9,15,'http://fuss10.elemecdn.com/e/d0/454efe08c57f735e1d8fe51abbf0bjpeg.jpeg',1542884585,0),
	(131452943,'吉利猪扒',9,15,'http://fuss10.elemecdn.com/e/39/87cec14fad4d441f242cf7f9263acjpeg.jpeg',1542884585,0),
	(131452958,'豆腐皮寿司',6,18,'http://fuss10.elemecdn.com/8/da/72f56efcba6b0377eea5f5b7c9fd7jpeg.jpeg',1542884585,0),
	(131452966,'无糖乌龙茶',6,19,'http://fuss10.elemecdn.com/a/e5/2ac132263d8f842bb6d134b658591jpeg.jpeg',1542884585,0),
	(131452967,'可口可乐',7,18,'http://fuss10.elemecdn.com/9/88/ba79eb50c67bddc714ee0bad8d81ajpeg.jpeg',1542884585,0),
	(137367967,'现配礼盒A',188,23,'http://fuss10.elemecdn.com/0/17/271a30e8a163cf92549d124d95da9jpeg.jpeg',1542884586,0),
	(137368349,'现配礼盒B',128,23,'http://fuss10.elemecdn.com/e/8d/8cf69b9664835889c4e1afe4123e7jpeg.jpeg',1542884586,0),
	(137368815,'豪华果篮',388,24,'http://fuss10.elemecdn.com/7/e2/5991b8429045aafdb3cb7ffeddea1jpeg.jpeg',1542884586,0),
	(140064732,'锅具炉具',28,50,'http://fuss10.elemecdn.com/4/ab/4886a93010c78aa1bf08981230e52jpeg.jpeg',1542884586,0),
	(140064736,'燃油',10,49,'http://fuss10.elemecdn.com/9/1d/64e131320cd02ffa7b137fb0f61bdjpeg.jpeg',1542884586,0),
	(140064758,'捞派鸭肠',20,53,'http://fuss10.elemecdn.com/e/e0/227bbc6e799f2c298191052162c41jpeg.jpeg',1542884586,0),
	(140064759,'捞派豆花',12,54,'http://fuss10.elemecdn.com/3/0c/d1be8b9bfc4c33f8590f4fbcf7d45jpeg.jpeg',1542884586,0),
	(140064761,'捞派毛肚',32,53,'http://fuss10.elemecdn.com/4/b9/a9939889595698fab9d1f781cb764jpeg.jpeg',1542884586,0),
	(140064771,'血旺',15,54,'http://fuss10.elemecdn.com/a/d7/8031fe6591a1d86df6f39fad5a715jpeg.jpeg',1542884586,0),
	(140064775,'新西兰羊肉',25,52,'http://fuss10.elemecdn.com/8/fb/bf70cd245c8bcc327430c904e07e4jpeg.jpeg',1542884586,0),
	(140064781,'鹌鹑蛋',15,55,'http://fuss10.elemecdn.com/b/53/9ed3844bdfa959bd2c870bd5b6eb5jpeg.jpeg',1542884586,0),
	(140064789,'藕片',9,57,'http://fuss10.elemecdn.com/9/71/771665c860a14023277eeb2c62e97jpeg.jpeg',1542884586,0),
	(140064791,'金针菇',12,57,'http://fuss10.elemecdn.com/8/2f/0ffdb9fd3d739357d143baf614de1jpeg.jpeg',1542884586,0),
	(140064793,'木耳',12,57,'http://fuss10.elemecdn.com/d/c9/c6efdb297167d3a0eb302fab8ad5djpeg.jpeg',1542884586,0),
	(140064795,'冻豆腐',11,58,'http://fuss10.elemecdn.com/2/95/0492708e1319cb587a81c0e99832ajpeg.jpeg',1542884586,0),
	(140064797,'红薯粉带',10,58,'http://fuss10.elemecdn.com/a/7f/f05813088ab3a66dac89e7aba557ejpeg.jpeg',1542884586,0),
	(140064800,'海带',9,57,'http://fuss10.elemecdn.com/c/9f/52796b009bcc3c2112878e9059cd8jpeg.jpeg',1542884586,0),
	(140064806,'笋片',14,57,'http://fuss10.elemecdn.com/4/84/07cdddaa402acb3d84c3b8b832c04jpeg.jpeg',1542884586,0),
	(140064808,'菠菜',10,59,'http://fuss10.elemecdn.com/4/74/4a75545b023a46483eca608c86918jpeg.jpeg',1542884586,0),
	(140064810,'五常米饭',3,60,'http://fuss10.elemecdn.com/d/6c/2df46c854b1e5abfcd44b1813eb75jpeg.jpeg',1542884586,0),
	(523003714,'芒果+奇异果+红心火龙果+凤梨【盒】',32.8,23,'http://fuss10.elemecdn.com/2/da/f8748fab07eed03c9f3339db14e81png.png',1542884586,0),
	(532708257,'鸭舌',27,54,'http://fuss10.elemecdn.com/c/62/baff5f080a6af3dd819394818d094jpeg.jpeg',1542884586,0),
	(533772660,'脱骨鸭掌',21,54,'http://fuss10.elemecdn.com/c/fb/b04f8ec7e14f28a182535728b806cjpeg.jpeg',1542884586,0),
	(549204663,'土豆',9,57,'http://fuss10.elemecdn.com/2/4e/30cb4c047d174cc1588e8a80dd42fjpeg.jpeg',1542884586,0),
	(550813916,'冬瓜',7,57,'http://fuss10.elemecdn.com/2/1c/bf2bfcfe5211ed3755a95bdd5e7e5jpeg.jpeg',1542884586,0),
	(550819074,'蟹味棒',17,54,'http://fuss10.elemecdn.com/8/3b/f5675fb56a418cb0e86f5f2625a97jpeg.jpeg',1542884586,0),
	(552424920,'山药',12,57,'http://fuss10.elemecdn.com/4/4e/765a2ff4ef5ec774fb0086d19683ajpeg.jpeg',1542884586,0),
	(552425744,'香菇',14,58,'http://fuss10.elemecdn.com/2/d8/ef104f0d04bfa832b6783c7475140jpeg.jpeg',1542884586,0),
	(552427340,'茼蒿',12,59,'http://fuss10.elemecdn.com/c/21/af470da16cc9cf1f6469dc9274b8djpeg.jpeg',1542884586,0),
	(610187734,'捞派鱼饼',14,53,'http://fuss10.elemecdn.com/c/a0/d5f78fde6614bd515a59f1854dd8ejpeg.jpeg',1542884586,0),
	(633141903,'草原羔羊肉',27,52,'http://fuss10.elemecdn.com/0/8e/71079e89b28b0854349d7c568c167jpeg.jpeg',1542884586,0),
	(633144374,'无刺巴沙鱼片',24,53,'http://fuss10.elemecdn.com/5/47/87e0de95f1bb43c5bb053e14a7128jpeg.jpeg',1542884586,0),
	(635586489,'美式鸡排堡',13,35,'http://fuss10.elemecdn.com/d/7a/bdac311f4df0f7de9af6ff2e4429ejpeg.jpeg',1542884586,0),
	(635587331,'美式鸡排堡套餐',26,36,'http://fuss10.elemecdn.com/7/13/fc42e5b905faf9226c26b98ff6cc1jpeg.jpeg',1542884586,0),
	(725810846,'【火】无籽玫瑰香洗净盒装 250g起',24.8,32,'http://fuss10.elemecdn.com/2/6b/0edd5f702612154a0445cb629e88apng.png',1542884586,0),
	(729762530,'哈蜜瓜+圣女果约300-500g起',24.8,21,'http://fuss10.elemecdn.com/9/f8/238cca7c87baed58059feb4feebddjpeg.jpeg',1542884586,0),
	(729771169,'白心火龙果+凤梨+圣女果 300g起',24.8,22,'http://fuss10.elemecdn.com/a/9d/fdd0a5f9228cf2cba98cbe329bd9cjpeg.jpeg',1542884586,0),
	(729771655,'芒果+白心火龙果+圣女果 300g起',24.8,21,'http://fuss10.elemecdn.com/a/78/632f88be11708b1bb1c1fc246e3b7jpeg.jpeg',1542884586,0),
	(729772030,'现切脆甜富士 约250g',7.58,32,'http://fuss10.elemecdn.com/1/10/5908ab668d2f07940148ec842e8f2jpeg.jpeg',1542884586,0),
	(729772243,'红提+玫瑰香+巨峰葡萄 300g起',24.8,21,'http://fuss10.elemecdn.com/d/c6/fafbc95e1ee555a53f965728d02d8jpeg.jpeg',1542884586,0),
	(729784313,'玫瑰香+红提+凤梨 300g起',24.8,21,'http://fuss10.elemecdn.com/c/ab/e4e9c1a65d698a85dccfa12e99b1cjpeg.jpeg',1542884586,0),
	(729785331,'红提+黑提+巨峰葡萄 300g起',24.8,21,'http://fuss10.elemecdn.com/d/d9/07fb1f069871fbc4ae732fe9f3982jpeg.jpeg',1542884586,0),
	(730259789,'巴沙鱼排',10,15,'http://fuss10.elemecdn.com/b/68/d053cd8eb8a4fcf10dc41009bdec9jpeg.jpeg',1542884585,0),
	(748928983,'澳橙鲜切盒 250g',29.9,32,'http://fuss10.elemecdn.com/7/e6/2386beab7079bb6ae92e347b2f903png.png',1542884586,0),
	(754916636,'草莓+芒果+龙眼 300g起',30.8,19,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754921110,'草莓+芒果+橙子 300g起',32.8,21,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754925489,'草莓+芒果+凤梨 300g起',30.8,19,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754928634,'草莓+红心火龙果+蜜瓜 300g起',30.8,19,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754932967,'香蕉+红心火龙果+凤梨 300g起',24.8,21,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754934532,'草莓+芒果+奇异果 300g起',30.8,20,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754934671,'草莓+芒果+红心火龙果 300g起',30.8,19,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754950376,'红提+红心火龙果+奇异果 300g起',24.8,21,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754954948,'草莓+芒果+蜜瓜 300g起',30.8,19,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(754964010,'西瓜+芒果+红提 300g起',24.8,21,'http://fuss10.elemecdn.com/5/63/2272808a2ebe1955e8c5a53aee8a6jpeg.jpeg',1542884586,0),
	(760906890,'牛肉鲜蔬番茄乌冬面',35,12,'http://fuss10.elemecdn.com/9/54/70e3dd7229ad8b5ca338f793d67f2jpeg.jpeg',1542884585,0),
	(760920666,'酸汤肥牛叉烧乌冬面',31,11,'http://fuss10.elemecdn.com/4/30/7daa9514ea0c51ec3ec7fd4b33319jpeg.jpeg',1542884585,0),
	(765164712,'香酥鸡柳',8,15,'http://fuss10.elemecdn.com/6/de/b5cfdc47f76e27c447b47111543bejpeg.jpeg',1542884585,0),
	(827343914,'蛋饺',14,54,'http://fuss10.elemecdn.com/b/60/ad2c9334da2d3a044e2f53e9edb4bjpeg.jpeg',1542884586,0),
	(827343951,'冻虾',33,56,'http://fuss10.elemecdn.com/c/92/9094ab07429e65333409d609bc8d9jpeg.jpeg',1542884586,0),
	(827357846,'肥肠',25,54,'http://fuss10.elemecdn.com/f/18/1cd8579096bc3ef99938fc7a41262jpeg.jpeg',1542884586,0),
	(827358124,'白萝卜',9,57,'http://fuss10.elemecdn.com/9/6c/4603540c3b4d55cd346371f41d429jpeg.jpeg',1542884586,0),
	(827362163,'椒香腰花',23,54,'http://fuss10.elemecdn.com/e/1e/c1871a1debb33381018c8da060310jpeg.jpeg',1542884586,0),
	(827362198,'脆皮肠',16,54,'http://fuss10.elemecdn.com/f/a9/9ec0db767d27d278accb1bd472b3ajpeg.jpeg',1542884586,0),
	(827362255,'鱿鱼须',27,57,'http://fuss10.elemecdn.com/6/fc/627e6ca21d087a7bbe0099502d51fjpeg.jpeg',1542884586,0),
	(827366910,'腐竹',16,58,'http://fuss10.elemecdn.com/c/d7/5e03d7847395f069f31c3f08e21bfjpeg.jpeg',1542884586,0),
	(827366969,'魔芋丝',8,59,'http://fuss10.elemecdn.com/9/ba/5fd5f4126e37b993985a4e7e62d06jpeg.jpeg',1542884586,0),
	(827367382,'娃娃菜',12,59,'http://fuss10.elemecdn.com/a/b3/fa53f1ca714ba207380dfbc6b108cjpeg.jpeg',1542884586,0),
	(827371159,'精品肥牛',29,53,'http://fuss10.elemecdn.com/6/97/fb0ec5a85665296dec7f78ab89ad6jpeg.jpeg',1542884586,0),
	(842823612,'迷你烟台小富士苹果6个装',24.8,24,'http://fuss10.elemecdn.com/5/18/f34aa024012f38299bfb8c9940937jpeg.jpeg',1542884586,0),
	(856386710,'(大杯)翡翠柠檬',15,43,'http://fuss10.elemecdn.com/8/85/4a296dba1ad85f4b77a818149d8c5jpeg.jpeg',1542884586,0),
	(856386758,'(大杯)四季春茶',9,43,'http://fuss10.elemecdn.com/f/40/36b649e9be8ff3280f9e210c211b3jpeg.jpeg',1542884586,0),
	(856386804,'(大杯)乌龙玛奇朵',15,44,'http://fuss10.elemecdn.com/f/be/2e32c6f0fbb7195ba2760bb5c8dfejpeg.jpeg',1542884586,0),
	(856386827,'(大杯)乌龙奶茶',13,44,'http://fuss10.elemecdn.com/8/a1/164c403c9d8b1093783c87c0a697ejpeg.jpeg',1542884586,0),
	(856386866,'(大杯)四季奶青',13,44,'http://fuss10.elemecdn.com/d/c7/70a9acc0512ffcd3fd3e74ee35068jpeg.jpeg',1542884586,0),
	(1677138213,'test',20,13,'',1546332462,0),
	(1677138214,'23333',23,13,'',1546335001,1546335106);

/*!40000 ALTER TABLE `food` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table order
# ------------------------------------------------------------

DROP TABLE IF EXISTS `order`;

CREATE TABLE `order` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `room_id` int(11) NOT NULL,
  `waiter_id` int(11) NOT NULL,
  `food_list` json NOT NULL,
  `total_price` double unsigned NOT NULL DEFAULT '0',
  `status` tinyint(4) NOT NULL,
  `create_at` int(11) NOT NULL,
  `finish_at` int(11) DEFAULT NULL,
  `delete_at` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;

INSERT INTO `order` (`id`, `room_id`, `waiter_id`, `food_list`, `total_price`, `status`, `create_at`, `finish_at`, `delete_at`)
VALUES
	(5,1,1,'[{\"Id\": 38947723, \"Name\": \"皇堡套餐\", \"Count\": 2, \"UnitPrice\": 39.0}]',78,4,1542958943,1546343990,1546344070);

/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table room
# ------------------------------------------------------------

DROP TABLE IF EXISTS `room`;

CREATE TABLE `room` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `floor` tinyint(4) unsigned NOT NULL,
  `status` tinyint(4) DEFAULT NULL,
  `last_update_at` int(11) DEFAULT NULL,
  `create_at` int(11) NOT NULL,
  `delete_at` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;

INSERT INTO `room` (`id`, `name`, `floor`, `status`, `last_update_at`, `create_at`, `delete_at`)
VALUES
	(1,'101',1,1,1542810220,1542810220,1546343363),
	(2,'102',1,1,1542810220,1542810220,0),
	(3,'103',1,1,1542810220,1542810220,0),
	(4,'104',1,1,1542810220,1542810220,0),
	(5,'105',1,1,1542810220,1542810220,0),
	(6,'106',1,1,1542810220,1542810220,0),
	(7,'107',1,1,1542810220,1542810220,0),
	(8,'108',1,1,1542810220,1542810220,0),
	(9,'109',1,1,1542810220,1542810220,0),
	(10,'110',1,1,1542958483,1542810220,0),
	(11,'111',1,1,1542810220,1542810220,0),
	(12,'112',1,1,1542810220,1542810220,0),
	(13,'113',1,1,1542810220,1542810220,0),
	(14,'114',1,1,1542810220,1542810220,0),
	(15,'115',1,1,1542810220,1542810220,0),
	(16,'201',2,1,1542810220,1542810220,0),
	(17,'202',2,1,1542810220,1542810220,0),
	(18,'203',2,1,1542810220,1542810220,0),
	(19,'204',2,1,1542810220,1542810220,0),
	(20,'205',2,1,1542810220,1542810220,0),
	(21,'206',2,1,1542810220,1542810220,0),
	(22,'207',2,1,1542810220,1542810220,0),
	(23,'208',2,1,1542810220,1542810220,0),
	(24,'209',2,1,1542810220,1542810220,0),
	(25,'210',2,1,1542810220,1542810220,0),
	(26,'211',2,1,1542810220,1542810220,0),
	(27,'212',2,1,1542810220,1542810220,0),
	(28,'213',2,1,1542810220,1542810220,0),
	(29,'214',2,1,1542810220,1542810220,0),
	(30,'215',2,1,1542810220,1542810220,0),
	(31,'301',3,1,1542810220,1542810220,0),
	(32,'302',3,1,1542810220,1542810220,0),
	(33,'303',3,1,1542810220,1542810220,0),
	(34,'304',3,1,1542810220,1542810220,0),
	(35,'305',3,1,1542810220,1542810220,0),
	(36,'306',3,1,1542810220,1542810220,0),
	(37,'307',3,1,1542810220,1542810220,0),
	(38,'308',3,1,1542810220,1542810220,0),
	(39,'309',3,1,1542810220,1542810220,0),
	(40,'310',3,1,1542810220,1542810220,0),
	(41,'311',3,1,1542810220,1542810220,0),
	(42,'312',3,1,1542810220,1542810220,0),
	(43,'313',3,1,1542810220,1542810220,0),
	(44,'314',3,1,1542810220,1542810220,0),
	(45,'315',3,1,1542810220,1542810220,0),
	(46,'401',4,1,1542810220,1542810220,0),
	(47,'402',4,1,1542810220,1542810220,0),
	(48,'403',4,1,1542810220,1542810220,0),
	(49,'404',4,1,1542810220,1542810220,0),
	(50,'405',4,1,1542810220,1542810220,0),
	(51,'406',4,1,1542810220,1542810220,0),
	(52,'407',4,1,1542810220,1542810220,0),
	(53,'408',4,1,1542810220,1542810220,0),
	(54,'409',4,1,1542810220,1542810220,0),
	(55,'410',4,1,1542810220,1542810220,0),
	(56,'411',4,1,1542810220,1542810220,0),
	(57,'412',4,1,1542810220,1542810220,0),
	(58,'413',4,1,1542810220,1542810220,0),
	(59,'414',4,1,1542810220,1542810220,0),
	(60,'415',4,1,1542810220,1542810220,0),
	(61,'501',5,1,1542810220,1542810220,0),
	(62,'502',5,1,1542810220,1542810220,0),
	(63,'503',5,1,1542810220,1542810220,0),
	(64,'504',5,1,1542810220,1542810220,0),
	(65,'505',5,1,1542810220,1542810220,0),
	(66,'506',5,1,1542810220,1542810220,0),
	(67,'507',5,1,1542810220,1542810220,0),
	(68,'508',5,1,1542810220,1542810220,0),
	(69,'509',5,1,1542810220,1542810220,0),
	(70,'510',5,1,1542810220,1542810220,0),
	(71,'511',5,1,1542810220,1542810220,0),
	(72,'512',5,1,1542810220,1542810220,0),
	(73,'513',5,1,1542810220,1542810220,0),
	(74,'514',5,1,1542810220,1542810220,0),
	(75,'515',5,1,1542810220,1542810220,0),
	(76,'601',6,1,1542810220,1542810220,0),
	(77,'602',6,1,1542810220,1542810220,0),
	(78,'603',6,1,1542810220,1542810220,0),
	(79,'604',6,1,1542810220,1542810220,0),
	(80,'605',6,1,1542810220,1542810220,0),
	(81,'606',6,1,1542810220,1542810220,0),
	(82,'607',6,1,1542810220,1542810220,0),
	(83,'608',6,1,1542810220,1542810220,0),
	(84,'609',6,1,1542810220,1542810220,0),
	(85,'610',6,1,1542810220,1542810220,0),
	(86,'611',6,1,1542810220,1542810220,0),
	(87,'612',6,1,1542810220,1542810220,0),
	(88,'613',6,1,1542810220,1542810220,0),
	(89,'614',6,1,1542810220,1542810220,0),
	(90,'615',6,1,1542810220,1542810220,0),
	(91,'701',7,1,1542810220,1542810220,0),
	(92,'702',7,1,1542810220,1542810220,0),
	(93,'703',7,1,1542810220,1542810220,0),
	(94,'704',7,1,1542810220,1542810220,0),
	(95,'705',7,1,1542810220,1542810220,0),
	(96,'706',7,1,1542810220,1542810220,0),
	(97,'707',7,1,1542810220,1542810220,0),
	(98,'708',7,1,1542810220,1542810220,0),
	(99,'709',7,1,1542810220,1542810220,0),
	(100,'710',7,1,1542810220,1542810220,0),
	(101,'711',7,1,1542810220,1542810220,0),
	(102,'712',7,1,1542810220,1542810220,0),
	(103,'713',7,1,1542810220,1542810220,0),
	(104,'714',7,1,1542810220,1542810220,0),
	(105,'715',7,1,1542810220,1542810220,0),
	(106,'801',8,1,1542810220,1542810220,0),
	(107,'802',8,1,1542810220,1542810220,0),
	(108,'803',8,1,1542810220,1542810220,0),
	(109,'804',8,1,1542810220,1542810220,0),
	(110,'805',8,1,1542810220,1542810220,0),
	(111,'806',8,1,1542810220,1542810220,0),
	(112,'807',8,1,1542810220,1542810220,0),
	(113,'808',8,1,1542810220,1542810220,0),
	(114,'809',8,1,1542810220,1542810220,0),
	(115,'810',8,1,1542810220,1542810220,0),
	(116,'811',8,1,1542810220,1542810220,0),
	(117,'812',8,1,1542810220,1542810220,0),
	(118,'813',8,1,1542810220,1542810220,0),
	(119,'814',8,1,1542810220,1542810220,0),
	(120,'815',8,1,1542810220,1542810220,0),
	(121,'901',9,1,1542810220,1542810220,0),
	(122,'902',9,1,1542810220,1542810220,0),
	(123,'903',9,1,1542810220,1542810220,0),
	(124,'904',9,1,1542810220,1542810220,0),
	(125,'905',9,1,1542810220,1542810220,0),
	(126,'906',9,1,1542810220,1542810220,0),
	(127,'907',9,1,1542810220,1542810220,0),
	(128,'908',9,1,1542810220,1542810220,0),
	(129,'909',9,1,1542810220,1542810220,0),
	(130,'910',9,1,1542810220,1542810220,0),
	(131,'911',9,1,1542810220,1542810220,0),
	(132,'912',9,1,1542810220,1542810220,0),
	(133,'913',9,1,1542810220,1542810220,0),
	(134,'914',9,1,1542810220,1542810220,0),
	(135,'915',9,1,1542810220,1542810220,0),
	(136,'1001',10,1,1542810220,1542810220,0),
	(137,'1002',10,1,1542810220,1542810220,0),
	(138,'1003',10,1,1542810220,1542810220,0),
	(139,'1004',10,1,1542810220,1542810220,0),
	(140,'1005',10,1,1542810220,1542810220,0),
	(141,'1006',10,1,1542810220,1542810220,0),
	(142,'1007',10,1,1542810220,1542810220,0),
	(143,'1008',10,1,1542810220,1542810220,0),
	(144,'1009',10,1,1542810220,1542810220,0),
	(145,'1010',10,1,1542810220,1542810220,0),
	(146,'1011',10,1,1542810220,1542810220,0),
	(147,'1012',10,1,1542810220,1542810220,0),
	(148,'1013',10,1,1542810220,1542810220,0),
	(149,'1014',10,1,1542810220,1542810220,0),
	(150,'1015',10,1,1542810220,1542810220,0),
	(151,'1101',11,1,1542810220,1542810220,0),
	(152,'1102',11,1,1542810220,1542810220,0),
	(153,'1103',11,1,1542810220,1542810220,0),
	(154,'1104',11,1,1542810220,1542810220,0),
	(155,'1105',11,1,1542810220,1542810220,0),
	(156,'1106',11,1,1542810220,1542810220,0),
	(157,'1107',11,1,1542810220,1542810220,0),
	(158,'1108',11,1,1542810220,1542810220,0),
	(159,'1109',11,1,1542810220,1542810220,0),
	(160,'1110',11,1,1542810220,1542810220,0),
	(161,'1111',11,1,1542810220,1542810220,0),
	(162,'1112',11,1,1542810220,1542810220,0),
	(163,'1113',11,1,1542810220,1542810220,0),
	(164,'1114',11,1,1542810220,1542810220,0),
	(165,'1115',11,1,1542810220,1542810220,0),
	(166,'1201',12,1,1542810220,1542810220,0),
	(167,'1202',12,1,1542810220,1542810220,0),
	(168,'1203',12,1,1542810220,1542810220,0),
	(169,'1204',12,1,1542810220,1542810220,0),
	(170,'1205',12,1,1542810220,1542810220,0),
	(171,'1206',12,1,1542810220,1542810220,0),
	(172,'1207',12,1,1542810220,1542810220,0),
	(173,'1208',12,1,1542810220,1542810220,0),
	(174,'1209',12,1,1542810220,1542810220,0),
	(175,'1210',12,1,1542810220,1542810220,0),
	(176,'1211',12,1,1542810220,1542810220,0),
	(177,'1212',12,1,1542810220,1542810220,0),
	(178,'1213',12,1,1542810220,1542810220,0),
	(179,'1214',12,1,1542810220,1542810220,0),
	(180,'1215',12,1,1542810220,1542810220,0),
	(181,'1301',13,1,1542810220,1542810220,0),
	(182,'1302',13,1,1542810220,1542810220,0),
	(183,'1303',13,1,1542810220,1542810220,0),
	(184,'1304',13,1,1542810220,1542810220,0),
	(185,'1305',13,1,1542810220,1542810220,0),
	(186,'1306',13,1,1542810220,1542810220,0),
	(187,'1307',13,1,1542810220,1542810220,0),
	(188,'1308',13,1,1542810220,1542810220,0),
	(189,'1309',13,1,1542810220,1542810220,0),
	(190,'1310',13,1,1542810220,1542810220,0),
	(191,'1311',13,1,1542810220,1542810220,0),
	(192,'1312',13,1,1542810220,1542810220,0),
	(193,'1313',13,1,1542810220,1542810220,0),
	(194,'1314',13,1,1542810220,1542810220,0),
	(195,'1315',13,1,1542810220,1542810220,0),
	(196,'1401',14,1,1542810220,1542810220,0),
	(197,'1402',14,1,1542810220,1542810220,0),
	(198,'1403',14,1,1542810220,1542810220,0),
	(199,'1404',14,1,1542810220,1542810220,0),
	(200,'1405',14,1,1542810220,1542810220,0),
	(201,'1406',14,1,1542810220,1542810220,0),
	(202,'1407',14,1,1542810220,1542810220,0),
	(203,'1408',14,1,1542810220,1542810220,0),
	(204,'1409',14,1,1542810220,1542810220,0),
	(205,'1410',14,1,1542810220,1542810220,0),
	(206,'1411',14,1,1542810220,1542810220,0),
	(207,'1412',14,1,1542810220,1542810220,0),
	(208,'1413',14,1,1542810220,1542810220,0),
	(209,'1414',14,1,1542810220,1542810220,0),
	(210,'1415',14,1,1542810220,1542810220,0),
	(211,'1501',15,1,1542810220,1542810220,0),
	(212,'1502',15,1,1542810220,1542810220,0),
	(213,'1503',15,1,1542810220,1542810220,0),
	(214,'1504',15,1,1542810220,1542810220,0),
	(215,'1505',15,1,1542810220,1542810220,0),
	(216,'1506',15,1,1542810220,1542810220,0),
	(217,'1507',15,1,1542810220,1542810220,0),
	(218,'1508',15,1,1542810220,1542810220,0),
	(219,'1509',15,1,1542810220,1542810220,0),
	(220,'1510',15,1,1542810220,1542810220,0),
	(221,'1511',15,1,1542810220,1542810220,0),
	(222,'1512',15,1,1542810220,1542810220,0),
	(223,'1513',15,1,1542810220,1542810220,0),
	(224,'1514',15,1,1542810220,1542810220,0),
	(225,'1515',15,1,1542810220,1542810220,0),
	(226,'1601',16,1,1542810220,1542810220,0),
	(227,'1602',16,1,1542810220,1542810220,0),
	(228,'1603',16,1,1542810220,1542810220,0),
	(229,'1604',16,1,1542810220,1542810220,0),
	(230,'1605',16,1,1542810220,1542810220,0),
	(231,'1606',16,1,1542810220,1542810220,0),
	(232,'1607',16,1,1542810220,1542810220,0),
	(233,'1608',16,1,1542810220,1542810220,0),
	(234,'1609',16,1,1542810220,1542810220,0),
	(235,'1610',16,1,1542810220,1542810220,0),
	(236,'1611',16,1,1542810220,1542810220,0),
	(237,'1612',16,1,1542810220,1542810220,0),
	(238,'1613',16,1,1542810220,1542810220,0),
	(239,'1614',16,1,1542810220,1542810220,0),
	(240,'1615',16,1,1542810220,1542810220,0),
	(241,'1701',17,1,1542810220,1542810220,0),
	(242,'1702',17,1,1542810220,1542810220,0),
	(243,'1703',17,1,1542810220,1542810220,0),
	(244,'1704',17,1,1542810220,1542810220,0),
	(245,'1705',17,1,1542810220,1542810220,0),
	(246,'1706',17,1,1542810220,1542810220,0),
	(247,'1707',17,1,1542810220,1542810220,0),
	(248,'1708',17,1,1542810220,1542810220,0),
	(249,'1709',17,1,1542810220,1542810220,0),
	(250,'1710',17,1,1542810220,1542810220,0),
	(251,'1711',17,1,1542810220,1542810220,0),
	(252,'1712',17,1,1542810220,1542810220,0),
	(253,'1713',17,1,1542810220,1542810220,0),
	(254,'1714',17,1,1542810220,1542810220,0),
	(255,'1715',17,1,1542810220,1542810220,0),
	(256,'1801',18,1,1542810220,1542810220,0),
	(257,'1802',18,1,1542810220,1542810220,0),
	(258,'1803',18,1,1542810220,1542810220,0),
	(259,'1804',18,1,1542810220,1542810220,0),
	(260,'1805',18,1,1542810220,1542810220,0),
	(261,'1806',18,1,1542810220,1542810220,0),
	(262,'1807',18,1,1542810220,1542810220,0),
	(263,'1808',18,1,1542810220,1542810220,0),
	(264,'1809',18,1,1542810220,1542810220,0),
	(265,'1810',18,1,1542810220,1542810220,0),
	(266,'1811',18,1,1542810220,1542810220,0),
	(267,'1812',18,1,1542810220,1542810220,0),
	(268,'1813',18,1,1542810220,1542810220,0),
	(269,'1814',18,1,1542810220,1542810220,0),
	(270,'1815',18,1,1542810220,1542810220,0),
	(271,'1901',19,1,1542810220,1542810220,0),
	(272,'1902',19,1,1542810220,1542810220,0),
	(273,'1903',19,1,1542810220,1542810220,0),
	(274,'1904',19,1,1542810220,1542810220,0),
	(275,'1905',19,1,1542810220,1542810220,0),
	(276,'1906',19,1,1542810220,1542810220,0),
	(277,'1907',19,1,1542810220,1542810220,0),
	(278,'1908',19,1,1542810220,1542810220,0),
	(279,'1909',19,1,1542810220,1542810220,0),
	(280,'1910',19,1,1542810220,1542810220,0),
	(281,'1911',19,1,1542810220,1542810220,0),
	(282,'1912',19,1,1542810220,1542810220,0),
	(283,'1913',19,1,1542810220,1542810220,0),
	(284,'1914',19,1,1542810220,1542810220,0),
	(285,'1915',19,1,1542810220,1542810220,0),
	(286,'2001',20,1,1542810220,1542810220,0),
	(287,'2002',20,1,1542810220,1542810220,0),
	(288,'2003',20,1,1542810220,1542810220,0),
	(289,'2004',20,1,1542810220,1542810220,0),
	(290,'2005',20,1,1542810220,1542810220,0),
	(291,'2006',20,1,1542810220,1542810220,0),
	(292,'2007',20,1,1542810220,1542810220,0),
	(293,'2008',20,1,1542810220,1542810220,0),
	(294,'2009',20,1,1542810220,1542810220,0),
	(295,'2010',20,1,1542810220,1542810220,0),
	(296,'2011',20,1,1542810220,1542810220,0),
	(297,'2012',20,1,1542810220,1542810220,0),
	(298,'2013',20,1,1542810220,1542810220,0),
	(299,'2014',20,1,1542810220,1542810220,0),
	(300,'2015',20,1,1542810220,1542810220,0),
	(302,'test',2,1,0,1546343369,0);

/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table room_history
# ------------------------------------------------------------

DROP TABLE IF EXISTS `room_history`;

CREATE TABLE `room_history` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `room_id` int(11) NOT NULL,
  `waiter_id` int(11) DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `status` tinyint(4) NOT NULL,
  `create_at` int(11) NOT NULL,
  `delete_at` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

LOCK TABLES `room_history` WRITE;
/*!40000 ALTER TABLE `room_history` DISABLE KEYS */;

INSERT INTO `room_history` (`id`, `room_id`, `waiter_id`, `name`, `status`, `create_at`, `delete_at`)
VALUES
	(1,10,1,'110',2,1542958454,0),
	(2,10,1,'110',1,1542958483,0);

/*!40000 ALTER TABLE `room_history` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table user
# ------------------------------------------------------------

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `salt` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `type` tinyint(4) DEFAULT NULL,
  `create_at` int(11) NOT NULL,
  `delete_at` int(11) DEFAULT NULL,
  `last_login_at` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;

INSERT INTO `user` (`id`, `username`, `password`, `salt`, `type`, `create_at`, `delete_at`, `last_login_at`)
VALUES
	(1,'waiter','+QMIHdoyoEn6Yka72UDlb2It50oVJjgRS/sRQ8b4xI0=','G098Pn6UaPp6/GwNOIAguA==',2,1542777917,0,0),
	(3,'admin','k018vE2m3VO+fVFZg9ljnVnWI+Wm/cC2asW+auiCg0A=','mXl7pKO5waILQxA5gVlXCg==',4,1546059255,0,0),
	(4,'root','rvXKI+fXX0uvgOOEej3xpnFrc5bebh0wy96IQRvAmHE=','A3dWokpzzsWKWMaEyUxPSA==',8,1546059273,0,0),
	(5,'waiter1','PHGKyGoOSV3AAdxun2Q7dLb90cHy93yk4k4C4fVe+1Y=','5dOKN/FvjUxRE9E6nbn0Ag==',2,1546340001,1546340069,0);

/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
