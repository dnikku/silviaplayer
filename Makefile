GAE_SDK=../appengine_sdk/google_appengine_1.6.5

run-webserver:
	$(GAE_SDK)/dev_appserver.py --address=0 --port=8010 --use_sqlite --datastore_path=../rdbms.sqlite3 .

run-deploy:
	$(GAE_SDK)/appcfg.py update .

appengine:
	echo $(GAE_SDK)/dev_appserver.py


clean-pyc:
	find . -name '*.pyc' | xargs rm

pip-freeze:
	pip freeze > REQUIREMENTS
	cat REQUIREMENTS
