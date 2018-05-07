import redis
import random
import logging
from flask import Flask, redirect, render_template, url_for, request,redirect,make_response,session
import time
from flask_script import Manager
from flask_bootstrap import Bootstrap

app = Flask(__name__)

bootstrap = Bootstrap(app)

rcon = redis.StrictRedis(host='localhost', db=5)
prodcons_queue = 'task:prodcons:queue'
pubsub_channel = 'task:pubsub:channel'

@app.route('/')
def index():

    html = """
<br>
<center><h3>Redis Message Queue</h3>
<br>
<a href="/prodcons">生产消费者模式</a>
<br>
<br>
<a href="/pubsub">发布订阅者模式</a>
<a href="/add/10">add</a>
</center>
"""
    return html

@app.route('/add/')
@app.route('/add/<id>')
def add(id=None):
    html = """
    add
    
    """+id
    return render_template('add.html', id=id) 

@app.route('/prodcons')
def prodcons():
    elem = random.randrange(10)
    rcon.lpush(prodcons_queue, elem)
    logging.info("lpush {} -- {}".format(prodcons_queue, elem))
    return redirect('/')

@app.route('/pubsub')
def pubsub():
    ps = rcon.pubsub()
    ps.subscribe(pubsub_channel)
    #elem = random.randrange(10)
    elem = time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time()))
    rcon.publish(pubsub_channel, elem)
    return redirect('/')

if __name__ == '__main__':
    app.run(debug=True)
