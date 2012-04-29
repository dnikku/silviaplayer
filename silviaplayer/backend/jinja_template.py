from jinja2 import Environment, FileSystemLoader
from os import path


FRONTEND_PATH = path.join(path.dirname(__file__), '..', 'frontend')

env = Environment(loader=FileSystemLoader(FRONTEND_PATH))


def render_template(template, **kwargs):
    tmpl = env.get_template(template)
    kwargs.update({
            'g': {
                'logged_user': 'nicu@local',
                'logout_url': '/logout',
                }
        })

    return tmpl.render(**kwargs)
