# Parse and modify the text
# Save to output text file

import re

def main():
	
	with open('d3_zach.txt') as f:
		list_of_words = re.findall(r'\S+|\n',f.read()) 


	c = 0
	newline_flag = False
	out_str = ""

	for w in list_of_words:
		
		if w != "\n":
			if newline_flag:
				if not re.match("^[a-zA-Z0-9_]*$", w):
					out_str += ("<link=" + str(c) + "><color=white>"+ w[:-1] + "</color></link>" + w[-1])
				else:
					out_str += ("<link=" + str(c) + "><color=white>"+ w + "</color></link>")
				
				out_str += " "
				newline_flag = False
			
			else:
				if not re.match("^[a-zA-Z0-9_]*$", w):
					out_str += ("<link=" + str(c) + "><color=white>"+ w[:-1] + "</color></link>" + w[-1])
				else:
					out_str += ("<link=" + str(c) + "><color=white>"+ w + "</color></link>")

				out_str += " "

			c += 1

		else:
			out_str += w
			newline_flag = True


	with open("d3_zach_mod.txt", 'r+') as out:
		out.write(out_str)

	f.close()
	out.close()

if __name__ == '__main__':
	main()