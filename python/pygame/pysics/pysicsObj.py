from random import randint, choice
from math import sin, cos, radians, copysign, floor
from vec2d import vec2d
import pygame
from pygame.locals import *

class object:

	def __init__(self, screen, world, name, size, type = None):
		self.screen = screen
		self.world = world
		self.mass = 0
		self.pos  = vec2d(-100,-100)
		self.vel = vec2d(0,0)
		self.frameVel = vec2d(0,0)
		self.acc = vec2d(0,0)
		self.frozen = 0
		self.name = name
		self.size = size
		self.color = pygame.Color(255,255,255)
		self.collided = 0
		
		if type:
			self.type = type

		self.index = self.world.append(self)
	
	
	def applyforce(self,force):
		if self.frozen:return 0
		self.acc += force/self.mass
		

	def draw(self):

		if self.type == 'circle':
			if self.collided:
				pygame.draw.circle(self.screen, pygame.Color(255,100,100),self.pos,self.size)
				self.collided = 0
			else:
				pygame.draw.circle(self.screen, self.color,self.pos,self.size)
'''		if self.type == 'rect':
			pygame.draw.rect(self.screen, (255, 255, 255), Rect(self.pos[0],self.pos[1],self.box[0],self.box[1]))
		if self.name == 'player':
			pygame.draw.rect(self.screen, (255, 255, 255), Rect(self.pos[0]-self.box/2,self.pos[1]-self.box/2,self.box,self.box))
			print(self.pos)
'''		

