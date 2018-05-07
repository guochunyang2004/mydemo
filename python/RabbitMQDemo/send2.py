#!/usr/bin/env python
import pika
from datetime import datetime
credentials = pika.PlainCredentials('admin', 'admin@21edu.com#')
connection = pika.BlockingConnection(pika.ConnectionParameters('10.160.84.75',5672,'',credentials))
channel = connection.channel()

channel.queue_declare(queue='MQDemoQueue',durable=True)
#fanout
#channel.exchange_declare(exchange='amq.fanout',type='fanout')

message='189'
channel.basic_publish(exchange='',
                      routing_key='MQDemoQueue',
                      body=message,
                      properties=pika.BasicProperties(
                         delivery_mode = 2, # make message persistent
                      ))
print(" %s Sent %s" % (datetime.now(),message))
connection.close()
