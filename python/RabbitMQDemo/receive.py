#!/usr/bin/env python
# -*- coding: utf-8 -*-
# auth : pangguoping

import pika
from datetime import datetime
import time

# ########################## 消费者 ##########################
credentials = pika.PlainCredentials('guest', 'guest')
# 连接到rabbitmq服务器
connection = pika.BlockingConnection(pika.ConnectionParameters('localhost',5672,'/',credentials))
channel = connection.channel()

# 声明消息队列，消息将在这个队列中进行传递。如果队列不存在，则创建
channel.queue_declare(queue='ConvertResourceQueue',durable=True)
#fanout模式
#channel.exchange_declare(exchange='amq.fanout',type='fanout')


# 定义一个回调函数来处理，这边的回调函数就是将信息打印出来。
def callback(ch, method, properties, body):
    print(" [x] %s Received %s" % (datetime.now(),body))
    time.sleep(2)
    print(" [x] %s Received end %s" % (datetime.now(),body))
    ch.basic_ack(delivery_tag = method.delivery_tag)

channel.basic_qos(prefetch_count=1)
# 告诉rabbitmq使用callback来接收信息
channel.basic_consume(callback,queue='ConvertResourceQueue',no_ack=False)
 # no_ack=True表示在回调函数中不需要发送确认标识

print(' [*] Waiting for messages. To exit press CTRL+C')

# 开始接收信息，并进入阻塞状态，队列里有信息才会调用callback进行处理。按ctrl+c退出。
channel.start_consuming()
