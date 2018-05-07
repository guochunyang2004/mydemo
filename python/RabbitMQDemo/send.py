#!/usr/bin/env python
import pika
from datetime import datetime
credentials = pika.PlainCredentials('guest', 'guest')
connection = pika.BlockingConnection(pika.ConnectionParameters('localhost',5672,'',credentials))
channel = connection.channel()
# 声明queue
channel.queue_declare(queue='ConvertResourceQueue',durable=True)
#fanout模式
#channel.exchange_declare(exchange='amq.fanout',type='fanout')

message='189'
channel.basic_publish(exchange='',
                      routing_key='ConvertResourceQueue',
                      body=message,
                      properties=pika.BasicProperties(
                         delivery_mode = 2, # make message persistent
                      ))
print(" %s Sent %s" % (datetime.now(),message))
connection.close()
