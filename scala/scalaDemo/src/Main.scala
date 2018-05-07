import org.apache.spark.{SparkConf, SparkContext}
object Main {
        def main(args: Array[String]) {
                println("Hello, world!")
                val conf = new SparkConf().setMaster("local").setAppName("Wordcount")
                val sc = new SparkContext(conf)
                val data = sc.textFile("d://spark.txt") // 文本存放的位置
                data.flatMap(_.split(" ")).map((_,1)).reduceByKey(_+_).collect().foreach(println)
        }
}